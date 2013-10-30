using KeyFreak.Base;
using KeyFreak.Commands;
using KeyFreak.Tools;
using KeyFreak.UI.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace KeyFreak.UI
{
	public class MainModel
	{
		private readonly CommandStack stack = new CommandStack();

		private readonly IDictionary<KeyCombination, IKeyCommand> globalKeys =
			new Dictionary<KeyCombination, IKeyCommand>();

		public MainModel()
		{
			LoadConfiguration();
		}

		public void LoadConfiguration()
		{
			ConfigurationHelper.LoadPlugins();

			ClearRegisteredCommands();

			//Register Root Command
			GlobalKeys.Add(KeysHelper.GetKeyCombination(Properties.Settings.Default.GlobalKey), rootCommand);

			var commands = ConfigurationHelper.GetCommands(globalKeys);
			if (commands != null)
			{
				foreach (var command in commands)
					RegisterMainLevelCommand(command);
			}

			ClearCommandStack();

			OnCommandListChanged(EventArgs.Empty);
		}

		private void ClearCommandStack()
		{
			stack.Clear();
		}

		private readonly IKeyCommandGroup rootCommand = new GroupCommand();

		private void ClearRegisteredCommands()
		{
			rootCommand.SubCommands.Clear();
			globalKeys.Clear();
		}

		private void RegisterMainLevelCommand(IKeyCommand keyCommand)
		{
			rootCommand.SubCommands.Add(keyCommand);
		}

		public string KeyCombination
		{
			get
			{
				return stack.KeyCombination;
			}
		}

		public IList<IKeyCommand> CommandsList
		{
			get
			{
				if (stack.Count == 0)
					return null;

				var group = stack.Peek() as IKeyCommandGroup;

				if (group == null)
					return null;

				return group.SubCommands;
			}
		}

		public void Clear()
		{
			CurrentContext = null;
			ClearCommandStack();
		}

		public void Up()
		{
			if (stack.Count > 1)
			{
				stack.Pop();
				OnCommandListChanged(EventArgs.Empty);
			}
		}

		/// <summary>
		/// Zwraca true jeżeli komenda została wykonana i nalezy schować formę
		/// </summary>
		public bool ExecuteOrExplore(Keys keyCode)
		{
			IKeyCommand keyCommand = CommandsList.FirstOrDefault(kc => kc.KeyCode == keyCode);
			if (keyCommand != null)
			{
				RunOrExplore(keyCommand);
				return true;
			}

			return false;
		}

		/// <summary>
		/// Zwraca true jeżeli komenda została wykonana i nalezy schować formę
		/// </summary>
		public bool ExecuteOrExploreGlobal(KeyCombination keyCode)
		{
			IKeyCommand keyCommand;
			if (GlobalKeys.TryGetValue(keyCode, out keyCommand))
			{
				RunOrExplore(keyCommand);
				return true;
			}

			return false;
		}

		private void RunOrExplore(IKeyCommand keyCommand)
		{
			var command = keyCommand as IRunableKeyCommand;
			if (command != null)
			{
				try
				{
					var thread = new Thread(() => command.Run(CurrentContext));
					thread.Start();
				}
				catch (Exception ex)
				{
					LogManager.Logger(GetType()).Error(ex.Message, ex);
				}
				OnCommandExecuted(EventArgs.Empty);
				return;
			}

			var group = keyCommand as IKeyCommandGroup;
			if (group != null)
			{
				stack.Push(group);
			}

			OnCommandListChanged(EventArgs.Empty);
		}

		public KeyCommandContext CurrentContext { get; set; }

		public IDictionary<KeyCombination, IKeyCommand> GlobalKeys
		{
			get { return globalKeys; }
		}

		#region events

		private void OnCommandListChanged(EventArgs e)
		{
			if (CommandListChanged != null)
				CommandListChanged(this, e);
		}

		public event EventHandler CommandListChanged;

		private void OnCommandExecuted(EventArgs e)
		{
			if (CommandExecuted  != null)
				CommandExecuted(this, e);
		}

		public event EventHandler CommandExecuted;

		#endregion events
	}
}