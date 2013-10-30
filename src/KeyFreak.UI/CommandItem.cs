using KeyFreak.Base;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KeyFreak
{
	public partial class CommandItem : UserControl
	{
		private IKeyCommand command;
		public IKeyCommand Command
		{
			get { return command; }
			set
			{
				command = value;
				if (command != null)
				{
					pictureBox1.Image = command.Icon;
					DescriptionLabel.Text = command.Description;
					KeyLabel.Text = command.KeyCode != Keys.None ? command.KeyCode.ToString() : String.Empty;
				}
				else
				{
					pictureBox1.Image = null;
					DescriptionLabel.Text = string.Empty;
					KeyLabel.Text = string.Empty;
				}
			}
		}

		public CommandItem()
		{
			InitializeComponent();
			LostFocus += CommandItem_LostFocus;
			GotFocus += CommandItem_GotFocus;
		}

		private void CommandItem_GotFocus(object sender, EventArgs e)
		{
			BackColor = SystemColors.MenuHighlight;
		}

		private void CommandItem_LostFocus(object sender, EventArgs e)
		{
			BackColor = Color.Transparent;
		}
	}
}