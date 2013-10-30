using KeyFreak.Base;
using System.Collections.Generic;

namespace KeyFreak.Commands
{
	/// <summary>
	/// Podstawowy plugin zawierający komendy wbudowane w aplikację.
	/// </summary>
	public class BasePlugin : IPlugin
	{
		public string NameSpace
		{
			get { return string.Empty; }
		}

		public IKeyCommand CreateCommand(string commandName, KeyCommandConfig config)
		{
			switch (commandName)
			{
				case "GroupCommand":
					return new GroupCommand
					{
						Id = config.Id,
						Icon = config.Icon,
						Description = config.Description,
						KeyCode = config.KeyCode
					};
				case "ShellCommand":
					return new ShellCommand
					{
						Id = config.Id,
						Icon = config.Icon,
						Description = config.Description,
						KeyCode = config.KeyCode,
						Parameters = config.Parameters
					};
				case "SequenceCommand":
					return new SequenceCommand
					{
						Id = config.Id,
						Icon = config.Icon,
						Description = config.Description,
						KeyCode = config.KeyCode,
						Parameters = config.Parameters
					};
			}

			return null;
		}

		public KeyCommandConfigurationControl CreateCommandConfigurationControl(string commandName)
		{
			switch (commandName)
			{
				case "GroupCommand":
					return null;
				case "ShellCommand":
					return new ShellCommandConfigurationControl();
				case "SequenceCommand":
					return null;
			}

			return null;
		}


		public IList<string> CommandsList
		{
			get 
			{
				return new List<string> 
				{
					"GroupCommand",
					"ShellCommand",
					"SequenceCommand"
				};
			}
		}
	}
}
