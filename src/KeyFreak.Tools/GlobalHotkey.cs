using KeyFreak.WinApi;
using System;
using System.Windows.Forms;

namespace KeyFreak.Tools
{
	public class GlobalHotkey
	{
		private readonly int modifier;
		private readonly int key;
		private readonly IntPtr hWnd;
		private readonly int id;

		public GlobalHotkey(MOD modifier, Keys key, Form form)
		{
			this.modifier = (int)modifier;
			this.key = (int)key;
			hWnd = form.Handle;
			id = GetHashCode();
		}

		public override sealed int GetHashCode()
		{
			return modifier ^ key ^ hWnd.ToInt32();
		}

		public bool Register()
		{
			return User32.RegisterHotKey(hWnd, id, modifier, key);
		}

		public bool Unregiser()
		{
			return User32.UnregisterHotKey(hWnd, id);
		}
	}
}