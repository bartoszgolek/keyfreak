using System.IO;
using KeyFreak.Tools;
using KeyFreak.UI;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace KeyFreak
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			log4net.Config.XmlConfigurator.Configure();

			string logs = "logs";
			string path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "KeyFreak"), logs);
			if (!Directory.Exists(path)) Directory.CreateDirectory(path);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			LogManager.Logger(typeof(Program)).InfoFormat("Application Run at: {0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
			Application.Run(new MainForm());
		}
	}
}