using KeyFreak.Base;
using KeyFreak.Tools;
using KeyFreak.UI.Configuration;
using KeyFreak.WinApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace KeyFreak.UI
{
	public partial class MainForm : Form
	{
		private const string SeparatorText = "-";
		private NotifyIcon notifyIcon;

		private readonly IList<GlobalHotkey> globalHotKeyRegistered = new List<GlobalHotkey>();

		private readonly IDictionary<Keys, Action<object, KeyEventArgs>> registeredSpecialKeys =
			new Dictionary<Keys, Action<object, KeyEventArgs>>();

		private readonly MainModel mainModel = new MainModel();

		public MainForm()
		{
			InitializeComponent();
			Deactivate += MainForm_Deactivate;

			RegiesterSpecialKeys();
			InitializeNotifyIcon();

			mainModel.CommandListChanged += mainModel_CommandListChanged;
			mainModel.CommandExecuted += mainModel_CommandExecuted;

			RefreshUi();
		}

		void mainModel_CommandExecuted(object sender, EventArgs e)
		{
			CloseKeyFreak();
		}

		void mainModel_CommandListChanged(object sender, EventArgs e)
		{
			RefreshUi();
		}

		private void InitializeNotifyIcon()
		{
			var contextMenu = new ContextMenu();
			contextMenu.MenuItems.Add(new MenuItem("Configuration...", OnConfiguration));
			contextMenu.MenuItems.Add(new MenuItem("Reload Configuration", OnReload));
			var separator = new MenuItem { Index = 1, Text = SeparatorText };
			contextMenu.MenuItems.Add(separator);

			contextMenu.MenuItems.Add(new MenuItem("About", OnAbout));

			var separator2 = new MenuItem { Index = 1, Text = SeparatorText };
			contextMenu.MenuItems.Add(separator2);

			contextMenu.MenuItems.Add(new MenuItem("Exit", OnExit));

			components = new Container();
			notifyIcon = new NotifyIcon(components)
				{
					Icon = Properties.Resources.KeyFreak,
					ContextMenu = contextMenu,
					Visible = true
				};
		}

		private void MainForm_Deactivate(object sender, EventArgs e)
		{
			CloseKeyFreak();
		}

		private void OnExit(object sender, EventArgs e)
		{
			Close();
		}

		private void OnAbout(object sender, EventArgs e)
		{
			var about = new AboutForm();
			about.Show();
		}

		private void OnConfiguration(object sender, EventArgs e)
		{
			var configurationForm = new ConfigurationForm { Settings = LoadSettings() };
			if (configurationForm.ShowDialog() == DialogResult.OK)
			{
				ConfigurationHelper.SaveSettings(configurationForm.Settings);
				ConfigurationHelper.SaveCommands(configurationForm.ConfigCommands);
				mainModel.LoadConfiguration();
			}
		}

		private AppSettings LoadSettings()
		{
			return new AppSettings
				{
					GlobalKey = Properties.Settings.Default.GlobalKey
				};
		}

		private void OnReload(object sender, EventArgs e)
		{
			mainModel.LoadConfiguration();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			//ShortCutsWatcher.KeyUp -= ShortCutsWatcher_KeyUp;
			//if (!ShortCutsWatcher.StopWatch())
			//	MessageBox.Show(Properties.Resources.HotkeyFailedToUnregister);

			var removed = new List<GlobalHotkey>();
			foreach (var ghk in globalHotKeyRegistered)
			{
				if (ghk.Unregiser())
				{
					removed.Add(ghk);
					LogManager.Logger(GetType()).InfoFormat("Hotkey registered");
				}
				else
				{
					LogManager.Logger(GetType()).ErrorFormat("Hotkey failed to register");
				}
			}

			foreach (var ghk in removed)
				globalHotKeyRegistered.Remove(ghk);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			RegisterGlobalKeys();
			//ShortCutsWatcher.KeyUp += ShortCutsWatcher_KeyUp;
			//if (!ShortCutsWatcher.StartWatch())
			//	MessageBox.Show(Properties.Resources.HotkeyFailedToUnregister);
		}

		//private void ShortCutsWatcher_KeyUp(object sender, KeyEventArgs e)
		//{
		//	IntPtr hWnd = User32.GetForegroundWindow();
		//	mainModel.CurrentContext = new KeyCommandContext { ActiveWindow = hWnd };

		//	e.Handled = mainModel.ExecuteOrExploreGlobal(e.KeyData);
		//}

		private void CloseKeyFreak()
		{
			Debug.WriteLine("CloseKeyFreak");
			Visible = false;
			WindowState = FormWindowState.Minimized;
		}

		private void RegisterSpecialKey(Keys key, Action<object, KeyEventArgs> action)
		{
			registeredSpecialKeys[key] = action;
		}

		private void RegiesterSpecialKeys()
		{
			RegisterSpecialKey(Keys.Down, DoNothing);
			RegisterSpecialKey(Keys.PageDown, DoNothing);
			RegisterSpecialKey(Keys.Up, DoNothing);
			RegisterSpecialKey(Keys.PageUp, DoNothing);
			RegisterSpecialKey(Keys.Return, DoNothing);
			RegisterSpecialKey(Keys.Enter, RunOrExploreCommand);
			RegisterSpecialKey(Keys.Back, GoUp);
			RegisterSpecialKey(Keys.Escape, GoEscape);
		}

		private void GoUp(object sender, KeyEventArgs e)
		{
			e.Handled = true;
			mainModel.Up();
			RefreshUi();
		}

		private void GoEscape(object sender, KeyEventArgs e)
		{
			e.Handled = true;
			CloseKeyFreak();
		}

		private void DoNothing(object sender, KeyEventArgs e)
		{
			e.Handled = false;
		}

		private void RunOrExploreCommand(object sender, KeyEventArgs e)
		{
			IKeyCommand command = commandsList1.CurrentCommand();
			if (command != null)
			{
				e.Handled = true;
				mainModel.ExecuteOrExplore(command.KeyCode);
			}
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (WindowState == FormWindowState.Minimized ||
				Visible == false)
			{
				e.Handled = true;
				return;
			}

			foreach (var registeredSpecialKey in
				registeredSpecialKeys.Where(registeredSpecialKey => registeredSpecialKey.Key == e.KeyCode))
			{
				registeredSpecialKey.Value(sender, e);
				return;
			}

			e.Handled = true;
			mainModel.ExecuteOrExplore(e.KeyCode);
		}

		private void RefreshUi()
		{
			if (mainModel.CommandsList == null || mainModel.CommandsList.Count == 0)
				return;

			Debug.WriteLine("RefreshUi");

			CurrentKeyCombination.Text = mainModel.KeyCombination;
			commandsList1.ApplyCommands(mainModel.CommandsList);

			if (commandsList1.Controls.Count > 0)
				commandsList1.Controls[0].Select();

			Height = commandsList1.Height + CurrentKeyCombination.Height;

			WindowState = FormWindowState.Normal;
			Visible = true;

			TopMost = true;
			TopLevel = true; 

			TopMost = false;
			TopLevel = false;

			Activate();

			TopMost = true;
			TopLevel = true;
		}

		private void RegisterGlobalKeys()
		{
			foreach (KeyCombination keyCombination in mainModel.GlobalKeys.Keys)
			{
				//Convert from managed to native enum
				var modifiers = (MOD)(int)keyCombination.Modifiers;

				var ghk = new GlobalHotkey(modifiers, keyCombination.Key, this);
				if (ghk.Register())
				{
					globalHotKeyRegistered.Add(ghk);
					LogManager.Logger(GetType()).InfoFormat("Hotkey '{0}' registered", keyCombination);
				}
				else
				{
					LogManager.Logger(GetType()).ErrorFormat("Hotkey '{0}' failed to register", keyCombination);
				}
			}
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == (int)WM.WM_HOTKEY)
			{
				mainModel.CurrentContext = new KeyCommandContext
				{
					ActiveWindow = User32.GetForegroundWindow()
				};

				// get the keys.
				var key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
				var modifier = (Modifiers)((int)m.LParam & 0xFFFF);

				mainModel.ExecuteOrExploreGlobal(new KeyCombination { Modifiers = modifier, Key = key });
			}
			base.WndProc(ref m);
		}
	}
}