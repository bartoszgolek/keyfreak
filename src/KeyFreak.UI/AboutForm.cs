using KeyFreak.UI.Properties;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace KeyFreak.UI
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
			Assembly assembly = Assembly.GetCallingAssembly();
			AssemblyName assemblyName = assembly.GetName();
			version.Text = Resources.AboutForm_AboutForm_version + assemblyName.Version.ToString(4);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("mailto:bartosz.golek@gmail.com");
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://bartosz.golek.biz");
		}
	}
}