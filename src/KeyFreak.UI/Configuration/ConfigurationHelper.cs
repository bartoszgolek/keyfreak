using KeyFreak.Base;
using KeyFreak.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KeyFreak.UI.Configuration
{
	public class ConfigurationHelper
	{
		private static readonly IList<IPlugin> Plugins = new List<IPlugin>();

		public static void LoadPlugins()
		{
			LogManager.Logger(typeof(ConfigurationHelper))
				.Info("Loading plugins...");
			Plugins.Clear();

			Plugins.Add(new Commands.BasePlugin());

			string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			if (path == null)
			{
				LogManager.Logger(typeof(ConfigurationHelper))
					.Warn("Nie powiodło się załadowanie konfiguracji komend. Nie odnaleziono ścieżki.");
				return;
			}

			foreach (string dll in Directory.GetFiles(Path.Combine(path, "plugins"), "*.dll"))
			{
				var assembly = Assembly.LoadFile(dll);
				foreach (var type in assembly.GetTypes())
				{
					if (typeof(IPlugin).IsAssignableFrom(type))
					{
						LogManager.Logger(typeof(ConfigurationHelper))
							.InfoFormat("Loading '{0}' plugin from '{1}'", type, dll);
						var plugin = (IPlugin)Activator.CreateInstance(type);
						Plugins.Add(plugin);
						LogManager.Logger(typeof(ConfigurationHelper))
							.InfoFormat("loaded with namespace '{0}'.", plugin.NameSpace);
					}
				}
			}
			LogManager.Logger(typeof(ConfigurationHelper))
				.Info("Plugins loaded.");
		}

		public static IList<string> GetAvailableCommands()
		{
			var result = new List<string>();
			foreach (IPlugin plugin in Plugins)
			{
				foreach (string command in plugin.CommandsList)
				{
					string commandType = command;
					if (plugin.NameSpace.Length > 0)
						commandType = plugin.NameSpace + ":" + commandType;
					result.Add(commandType);
				}
			}
			return result;
		}

		public static IList<IKeyCommand> GetCommands(IDictionary<KeyCombination, IKeyCommand> globalCommands)
		{
			var result = new List<IKeyCommand>();
			var commands = new Dictionary<string, IKeyCommand>();

			var configCommands = GetConfigCommands();

			foreach (var configCommand in configCommands)
			{
				IKeyCommand command = CreateCommand(configCommand);

				if (!String.IsNullOrWhiteSpace(configCommand.GlobalKey))
					globalCommands.Add(KeysHelper.GetKeyCombination(configCommand.GlobalKey), command);

				if (command == null)
				{
					LogManager.Logger(typeof(ConfigurationHelper))
						.WarnFormat("Nie powiodło się u instancji komendy [{0}], nie odnalezione typu '{1}'.", configCommand.Id, configCommand.CommandType);
					continue;
				}

				commands.Add(configCommand.Id, command);
			}

			foreach (var configCommand in configCommands)
			{
				var command = commands[configCommand.Id];
				if (string.IsNullOrEmpty(configCommand.Parent))
				{
					result.Add(command);
				}
				else
				{
					if (commands.ContainsKey(configCommand.Parent))
					{
						var group = commands[configCommand.Parent] as IKeyCommandGroup;
						if (group != null)
						{
							group.SubCommands.Add(command);
						}
						else
						{
							LogManager.Logger(typeof(ConfigurationHelper))
								.ErrorFormat("Komenda [{0}], nie implementuje interfejsu IKeyCommandGroup, nie można dodać potomka.", configCommand.Parent);
							LogManager.Logger(typeof(ConfigurationHelper))
								.WarnFormat("Komenda [{0}] została pominięta.", configCommand.Id);
						}
					}
					else
					{
						LogManager.Logger(typeof(ConfigurationHelper))
							.ErrorFormat("Komenda [{0}], nie istnieje, nie można dodać potomka.", configCommand.Parent);
						LogManager.Logger(typeof(ConfigurationHelper))
							.WarnFormat("Komenda [{0}] została pominięta.", configCommand.Id);
					}
				}
			}

			return result;
		}

		private static ConfigCommand ReadCommandFromConfig(XElement element)
		{
			var configCommand = new ConfigCommand();
			var node = element;
			if (node != null)
			{
				configCommand.Id = node.Attribute("id").Value;
				configCommand.Key = node.Attribute("key").Value;
				configCommand.CommandType = node.Attribute("commandType").Value;

				var attr = node.Attribute("parent");
				if (attr != null)
					configCommand.Parent = attr.Value;

				attr = node.Attribute("parameters");
				if (attr != null)
					configCommand.Parameters = attr.Value;

				attr = node.Attribute("iconPath");
				if (attr != null)
					configCommand.IconPath = attr.Value;

				attr = node.Attribute("description");
				if (attr != null)
					configCommand.Description = attr.Value;

				attr = node.Attribute("globalKey");
				if (attr != null)
					configCommand.GlobalKey = attr.Value;
			}
			return configCommand;
		}

		public static IKeyCommand CreateCommand(ConfigCommand item)
		{
			var manifest = GetCommandManifest(item.CommandType);
			IPlugin plugin = Plugins.FirstOrDefault(p => p.NameSpace == manifest.NameSpace);

			if (plugin == null)
			{
				LogManager.Logger(typeof(ConfigurationHelper))
					.Error("Błąd tworzenia komendy. Nie znaleziono pluginu.");
				LogManager.Logger(typeof(ConfigurationHelper))
					.WarnFormat("Komenda [{0}] została pominięta.", item.Id);
				return null;
			}

			try
			{
				IKeyCommand command = plugin.CreateCommand(
					manifest.Command,
					new KeyCommandConfig
					{
						Id = item.Id,
						Description = item.Description,
						Icon = GetImage(item.IconPath),
						Parameters = item.Parameters,
						KeyCode = GetKeys(item.Key)
					});

				if (command != null)
					return command;

				LogManager.Logger(typeof(ConfigurationHelper))
					.Error("Błąd tworzenia komendy. Plugin nie zwrócił instancji.");
				LogManager.Logger(typeof(ConfigurationHelper))
					.WarnFormat("Komenda [{0}] została pominięta.", item.Id);
			}
			catch (Exception ex)
			{
				LogManager.Logger(typeof(ConfigurationHelper))
					.Error("Błąd tworzenia komendy", ex);
				LogManager.Logger(typeof(ConfigurationHelper))
					.WarnFormat("Komenda [{0}] została pominięta.", item.Id);
			}

			return null;
		}

		public static KeyCommandConfigurationControl CreateCommandConfigurationControl(string commandType)
		{
			if (string.IsNullOrEmpty(commandType))
				return null;

			var manifest = GetCommandManifest(commandType);
			IPlugin plugin = Plugins.FirstOrDefault(p => p.NameSpace == manifest.NameSpace);

			if (plugin == null)
				return null;

			try
			{
				return plugin.CreateCommandConfigurationControl(manifest.Command);
			}
			catch
			{
				return null;
			}
		}

		private static CommandManifest GetCommandManifest(string commandType)
		{
			var manifest = new CommandManifest();
			string[] typeParts = commandType.Split(new[] { ':' }, 2);
			if (typeParts.Length == 1)
			{
				manifest.NameSpace = string.Empty;
				manifest.Command = typeParts[0];
			}
			else
			{
				manifest.NameSpace = typeParts[0];
				manifest.Command = typeParts[1];
			}
			return manifest;
		}

		private static Image GetImage(string iconPath)
		{
			return !String.IsNullOrEmpty(iconPath) && File.Exists(iconPath) ? Image.FromFile(iconPath) : null;
		}

		private static Keys GetKeys(string key)
		{
			return (Keys)Enum.Parse(typeof(Keys), key);
		}

		private static readonly string CommandsPath = Path.Combine(AppDataPath, "commands.xml");

		public static IList<ConfigCommand> GetConfigCommands()
		{
			const string commandsXml = "commands.xml";
			const string commandsXmlDefault = "commands.xml.default";

			LogManager.Logger(typeof(ConfigurationHelper))
				.Info("Loading configuration...");
			var configCommands = new List<ConfigCommand>();

			if (!Directory.Exists(AppDataPath))
				Directory.CreateDirectory(AppDataPath);

			//jeżeli istnieje to przenieś plik ze starej lokalizacji
			if (!File.Exists(CommandsPath) && File.Exists(commandsXml))
				File.Move(commandsXml, CommandsPath);

			//jeżeli nie ma pliku konfiguracyjnego to utwóz z domyślnego
			if (!File.Exists(CommandsPath) && File.Exists(commandsXmlDefault))
				File.Copy(commandsXmlDefault, CommandsPath);

			//Jeżeli nadal nie ma pliku konfiguracyjnego to coś jest nei tak
			if (!File.Exists(CommandsPath))
			{
				LogManager.Logger(typeof(ConfigurationHelper))
					.Warn("Nie odnaleziono pliku konfiguracji.");
				return configCommands;
			}

			XDocument document;
			using (var commandFileStream = new FileStream(CommandsPath, FileMode.Open, FileAccess.Read))
			{
				document = XDocument.Load(commandFileStream);
			}

			var root = document.Root;
			if (root == null)
			{
				LogManager.Logger(typeof(ConfigurationHelper))
					.Warn("Nie powiodło się załadowanie konfiguracji komend. Brak głównej gałęzi w pliku konfiguracji.");
				return configCommands;
			}

			var keyCommands = root.Element("keyCommands");
			if (keyCommands == null)
			{
				LogManager.Logger(typeof(ConfigurationHelper))
					.Warn("Nie powiodło się załadowanie konfiguracji komend. Brak gałęzi 'keyCommands' w pliku konfiguracji.");
				return configCommands;
			}

			configCommands.AddRange(keyCommands.Elements("command").Select(ReadCommandFromConfig));

			LogManager.Logger(typeof(ConfigurationHelper))
				.Info("Configuration loaded.");

			return configCommands;
		}

		public static string AppDataPath
		{
			get
			{
				var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "KeyFreak");

				return fileName;
			}
		}

		public static void SaveCommands(IList<ConfigCommand> configCommands)
		{
			XDocument document;
			using (var commandFileStream = new FileStream(CommandsPath, FileMode.Open, FileAccess.Read))
			{
				document = XDocument.Load(commandFileStream);
			}

			var root = document.Root;
			if (root == null)
			{
				LogManager.Logger(typeof(ConfigurationHelper))
					.Warn("Nie powiodło się załadowanie konfiguracji komend. Brak głównej gałęzi w pliku konfiguracji.");
				return;
			}

			var keyCommands = root.Element("keyCommands");
			if (keyCommands == null)
			{
				LogManager.Logger(typeof(ConfigurationHelper))
.Warn("Nie powiodło się załadowanie konfiguracji komend. Brak gałęzi 'keyCommands' w pliku konfiguracji.");
				return;
			}

			keyCommands.RemoveAll();
			foreach (var configCommand in configCommands)
			{
				var commandElement = new XElement("command");
				commandElement.Add(new XAttribute("id", configCommand.Id));
				commandElement.Add(new XAttribute("key", configCommand.Key));

				if (!string.IsNullOrWhiteSpace(configCommand.Parent))
					commandElement.Add(new XAttribute("parent", configCommand.Parent));

				if (!string.IsNullOrWhiteSpace(configCommand.Description))
					commandElement.Add(new XAttribute("description", configCommand.Description));

				commandElement.Add(new XAttribute("commandType", configCommand.CommandType));

				if (!string.IsNullOrWhiteSpace(configCommand.Parameters))
					commandElement.Add(new XAttribute("parameters", configCommand.Parameters));

				if (!string.IsNullOrWhiteSpace(configCommand.IconPath))
					commandElement.Add(new XAttribute("iconPath", configCommand.IconPath));

				if (!string.IsNullOrWhiteSpace(configCommand.GlobalKey))
					commandElement.Add(new XAttribute("globalKey", configCommand.GlobalKey));

				keyCommands.Add(commandElement);
			}

			using (var commandFileStream = new FileStream(CommandsPath, FileMode.Create, FileAccess.Write))
			{
				document.Save(commandFileStream);
			}
		}

		public static void SaveSettings(AppSettings settings)
		{
			Properties.Settings.Default.GlobalKey = settings.GlobalKey;
			Properties.Settings.Default.Save();
		}
	}

	public class AppSettings
	{
		public string GlobalKey { get; set; }
	}
}