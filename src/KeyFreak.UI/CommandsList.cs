using KeyFreak.Base;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KeyFreak
{
	public partial class CommandsList : UserControl
	{
		private readonly IList<IKeyCommand> keys = new List<IKeyCommand>();
		public IList<IKeyCommand> Keys
		{
			get { return keys; }
		}

		public CommandsList()
		{
			InitializeComponent();
			ControlAdded += CommandsList_ControlAdded;
			ControlRemoved += CommandsList_ControlRemoved;
		}

		private void CommandsList_ControlRemoved(object sender, ControlEventArgs e)
		{
			Height -= e.Control.Height;
		}

		private void CommandsList_ControlAdded(object sender, ControlEventArgs e)
		{
			e.Control.Dock = DockStyle.Bottom;
			if (Controls.Count == 1)
				Height = e.Control.Height;
			else
				Height += e.Control.Height;
		}

		public void AddItem(CommandItem item)
		{
			Controls.Add(item);
			keys.Add(item.Command);
		}

		public void Clear()
		{
			Controls.Clear();
			keys.Clear();
		}

		public IKeyCommand CurrentCommand()
		{
			return Controls.Cast<Control>()
				.Where(control => control.Focused)
				.OfType<CommandItem>()
				.Select(commandItem => commandItem.Command)
				.FirstOrDefault();
		}

		public void ApplyCommands(IEnumerable<IKeyCommand> commands)
		{
			Clear();
			if (commands != null)
			{
				foreach (var command in commands)
					AddItem(new CommandItem { Command = command });
			}
		}
	}
}