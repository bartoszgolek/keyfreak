using System;
using System.Windows.Forms;

namespace KeyFreak.Tools
{
	public static class KeysHelper
	{
		private const string Win = "WIN";
		private const string Shift = "SHIFT";
		private const string Ctrl = "CONTROL";
		private const string Alt = "ALT";

		public static KeyCombination GetKeyCombination(string key)
		{
			var result = new KeyCombination();

			if (ModifierWin(key))
				result.Modifiers = result.Modifiers | Modifiers.Win;

			if (ModifierControl(key))
				result.Modifiers = result.Modifiers | Modifiers.Control;

			if (ModifierAlt(key))
				result.Modifiers = result.Modifiers | Modifiers.Alt;

			if (ModifierShift(key))
				result.Modifiers = result.Modifiers | Modifiers.Shift;

			result.Key = GetKeyCodeFromStringWithoutModifiers(key);

			return result;
		}

		public static KeyCombination GetKeyCombination(Keys key)
		{
			var result = new KeyCombination();

			if ((key & Keys.LWin) == Keys.LWin)
			{
				result.Modifiers = result.Modifiers | Modifiers.Win;
				key = key & ~Keys.LWin;
			}

			if ((key & Keys.RWin) == Keys.RWin)
			{
				result.Modifiers = result.Modifiers | Modifiers.Win;
				key = key & ~Keys.RWin;
			}

			if ((key & Keys.Control) == Keys.Control)
			{
				result.Modifiers = result.Modifiers | Modifiers.Control;
				key = key & ~Keys.Control;
			}

			if ((key & Keys.Alt) == Keys.Alt)
			{
				result.Modifiers = result.Modifiers | Modifiers.Alt;
				key = key & ~Keys.Alt;
			}

			if ((key & Keys.Shift) == Keys.Shift)
			{
				result.Modifiers = result.Modifiers | Modifiers.Shift;
				key = key & ~Keys.Shift;
			}

			result.Key = key;

			return result;
		}

		public static string ToString(KeyCombination k)
		{
			string message = String.Empty;

			if (k.Key == Keys.None && k.Modifiers == Modifiers.None)
				return message;

			if ((k.Modifiers & Modifiers.Control) == Modifiers.Control)
				message += Ctrl + " + ";

			if ((k.Modifiers & Modifiers.Shift) == Modifiers.Shift)
				message += Shift + " + ";

			if ((k.Modifiers & Modifiers.Alt) == Modifiers.Alt)
				message += Alt + " + ";

			if ((k.Modifiers & Modifiers.Win) == Modifiers.Win)
				message += "Win + ";

			message += k.Key.ToString();

			return message;
		}

		private static Keys GetKeyCodeFromStringWithoutModifiers(string key)
		{
			string[] keys = key.Split('+');
			string s1 = keys[keys.Length - 1].Trim();

			try
			{
				return (Keys)Enum.Parse(typeof(Keys), s1, false);
			}
			catch (Exception ex)
			{
				LogManager.Logger(typeof(KeysHelper)).Debug(ex.ToString());
			}

			return Keys.None;
		}

		private static bool ModifierWin(string key)
		{
			return key.ToUpper().Contains(Win);
		}

		private static bool ModifierAlt(string key)
		{
			return key.ToUpper().Contains(Alt);
		}

		private static bool ModifierControl(string key)
		{
			return key.ToUpper().Contains(Ctrl);
		}

		private static bool ModifierShift(string key)
		{
			return key.ToUpper().Contains(Shift);
		}
	}
}
