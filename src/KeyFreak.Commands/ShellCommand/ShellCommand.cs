using System.Globalization;
using KeyFreak.Base;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using KeyFreak.Tools;

namespace KeyFreak.Commands
{
	public class ShellCommand : IRunableKeyCommand
	{
		public string Id { get; set; }
		public Keys KeyCode { get; set; }
		public string Description { get; set; }
		public string Parameters { get; set; }

		private Image icon = Properties.Resources.system;
		public Image Icon
		{
			get
			{
				if (icon == null)
				{
					if (!String.IsNullOrWhiteSpace(Parameters))
					{
						string paraemters;

						string iconPath = GetShellCommand(out paraemters);
						if (File.Exists(iconPath))
						{
							Icon ico = System.Drawing.Icon.ExtractAssociatedIcon(iconPath);

							if (ico != null)
								return ico.ToBitmap();
						}
					}

					return Properties.Resources.system;
				}

				return icon;
			}
			set
			{
				icon = value;
			}
		}

		public void Run(KeyCommandContext context)
		{
			string paraemters;
			string shellCommand = GetShellCommand(out paraemters);

			if (!string.IsNullOrWhiteSpace(shellCommand))
			{
				Process p = Process.Start(shellCommand, paraemters);
				if (p != null)
				{
					try
					{
						p.WaitForInputIdle();
					}
					catch (InvalidOperationException)
					{
						LogManager.Logger(GetType()).Debug("Can't wait for Idle, process does not have UI.");
					}
					p.WaitForExit();
				}
			}
		}

		private string GetShellCommand(out string parameters)
		{
			parameters = string.Empty;
			string shellCommand = string.Empty;

			string[] parametersArray = Parameters != null ? Parameters.Split(new[] { ';' }) : null;
			if (parametersArray != null && parametersArray.Length > 0)
			{
				shellCommand = parametersArray[0].ToString(CultureInfo.InvariantCulture);

				var sb = new StringBuilder();
				for (int i = 1; i < parametersArray.Length; i++)
				{
					sb.Append(" ");
					sb.Append(parametersArray[i]);
				}

				parameters = sb.ToString().Trim();
			}

			return shellCommand;
		}
	}
}