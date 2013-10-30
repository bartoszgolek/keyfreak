using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyFreak.Base;

namespace KeyFreak.Commands
{
	public partial class ShellCommandConfigurationControl : KeyCommandConfigurationControl
	{
		public ShellCommandConfigurationControl()
		{
			InitializeComponent();
		}

		private const char Separator = ';';
		public override string Parameters
		{
			get
			{
				return commandPathTextBox.Text +
					(!String.IsNullOrWhiteSpace(commandParamatersTextBox.Text)
						? Separator.ToString() + commandParamatersTextBox.Text
						: String.Empty);
			}
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					var param = value.Split(new[] { Separator });
					commandPathTextBox.Text = param[0];
					if (param.Length > 1)
						commandParamatersTextBox.Text = param[1];
					else
						commandParamatersTextBox.Text = string.Empty;
				}
				else
				{
					commandPathTextBox.Text = string.Empty;
					commandParamatersTextBox.Text = string.Empty;
				}
			}
		}

		private void browseCommandButton_Click(object sender, EventArgs e)
		{
			if (browseCommandDialog.ShowDialog() == DialogResult.OK)
			{
				this.commandPathTextBox.Text = browseCommandDialog.FileName;
			}

			OnParametersChanged();
		}

		private void OnLeave(object sender, EventArgs e)
		{
			OnParametersChanged();
		}
	}
}
