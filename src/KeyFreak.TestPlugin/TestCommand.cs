using KeyFreak.Base;
using KeyFreak.TestPlugin.Properties;
using KeyFreak.WinApi;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KeyFreak.TestPlugin
{
	public class TestCommand : IRunableKeyCommand
	{
		public string Id { get; set; }
		public Keys KeyCode { get; set; }
		public string Parameters { get; set; }

		private string description = "TestCommand";
		public string Description
		{
			get
			{
				return description;
			}
			set
			{
				description = !String.IsNullOrEmpty(value) ? value : "TestCommand";
			}
		}

		private Image icon = Resources.bulb;
		public Image Icon
		{
			get
			{
				return icon;
			}
			set
			{
				icon = value ?? Resources.bulb;
			}
		}

		public void Run(KeyCommandContext context)
		{
			var messageParams = string.Empty;
			string[] parametersArray = Parameters != null ? Parameters.Split(new[] { ';' }) : null;
			if (parametersArray != null)
			{
				var sb = new StringBuilder();
				foreach (var param in parametersArray)
				{
					sb.Append(", ");
					sb.Append(param);
				}

				messageParams = sb.ToString();
				if (messageParams.Length > 1)
					messageParams = messageParams.Substring(2);
			}

			var wText = new StringBuilder();
			if (context != null && context.ActiveWindow != null)
			{
				User32.GetWindowText(context.ActiveWindow, wText, 255);

				MessageBox.Show(Description + Environment.NewLine +
					Resources.TestCommand_Run_ActiveWindow__ + wText + Environment.NewLine +
					Resources.TestCommand_Run_Parameters_ + messageParams, Resources.TestCommand_Run_Test);
			}
			else
			{
				MessageBox.Show(Description + Environment.NewLine +
					Resources.TestCommand_Run_ActiveWindow__ + Resources.TestCommand_Run__No_Active_Window_ + Environment.NewLine +
					Resources.TestCommand_Run_Parameters_ + messageParams, Resources.TestCommand_Run_Test);
			}
		}
	}
}