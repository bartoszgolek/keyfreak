using System.Windows.Forms;

namespace KeyFreak.Tools
{
	public class KeyCombinationHelper
	{
		public Keys pressedCombination;
		public bool altPressed = false;
		public bool ctrlPressed = false;
		public bool shiftPressed = false;
		public bool winPressed = false;

		public event KeyEventHandler KeyDown;

		public event KeyEventHandler KeyUp;

		public bool SetKeyUp(Keys keyData)
		{
			switch (keyData)
			{
				case Keys.LMenu:
				case Keys.RMenu:
					altPressed = false;
					return false;
				case Keys.LControlKey:
				case Keys.RControlKey:
					ctrlPressed = false;
					return false;
				case Keys.LShiftKey:
				case Keys.RShiftKey:
					shiftPressed = false;
					return false;
				case Keys.LWin:
				case Keys.RWin:
					winPressed = false;
					return false;
			}

			var e = new KeyEventArgs(pressedCombination);
			if (KeyUp != null)
				KeyUp(this, e);

			return e.Handled;
		}

		public bool SetKeyDown(Keys keyData)
		{
			switch (keyData)
			{
				case Keys.LMenu:
				case Keys.RMenu:
					altPressed = true;
					return false;
				case Keys.LControlKey:
				case Keys.RControlKey:
					ctrlPressed = true;
					return false;
				case Keys.LShiftKey:
				case Keys.RShiftKey:
					shiftPressed = true;
					return false;
				case Keys.LWin:
				case Keys.RWin:
					winPressed = true;
					return false;
			}

			if (altPressed)
				keyData = keyData | Keys.Alt;

			if (ctrlPressed)
				keyData = keyData | Keys.Control;

			if (shiftPressed)
				keyData = keyData | Keys.Shift;

			if (winPressed)
				keyData = keyData | Keys.LWin;

			pressedCombination = keyData;

			var e = new KeyEventArgs(pressedCombination);
			if (KeyDown != null)
				KeyDown(this, e);

			return e.Handled;
		}
	}
}
