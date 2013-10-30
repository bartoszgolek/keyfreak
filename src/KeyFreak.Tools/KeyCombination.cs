using System.Windows.Forms;

namespace KeyFreak.Tools
{
	public class KeyCombination
	{
		public Modifiers Modifiers { get; set; }
		public Keys Key { get; set; }

		public override int GetHashCode()
		{
			return Modifiers.GetHashCode() * Key.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			var kc = obj as KeyCombination;
			if (kc == null)
				return false;

			if (!Modifiers.Equals(kc.Modifiers))
				return false;

			return Key.Equals(kc.Key);
		}

		public override string ToString()
		{
			return KeysHelper.ToString(this);
		}
	}
}
