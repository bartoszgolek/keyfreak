using KeyFreak.Tools;
using System;
using System.Windows.Forms;

namespace KeyFreak.UI
{
	public partial class GetShortCutKeyCode : Form
	{
		private KeyCombination shortCutValue;

		public KeyCombination ShortCut
		{
			get
			{
				return shortCutValue;
			}
			set
			{
				shortCutValue = value;
				SetKeyText();
			}
		}

		public GetShortCutKeyCode()
		{
			InitializeComponent();
			keyCombinationHelper.KeyDown += keyCombinationHelper_KeyDown;
		}

		private void keyCombinationHelper_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.Control | Keys.ControlKey))
				return;

			if (e.KeyData == (Keys.Alt | Keys.LMenu))
				return;

			if (e.KeyData == (Keys.Alt | Keys.Control | Keys.Menu))
				return;

			if (e.KeyData == (Keys.Shift | Keys.ShiftKey))
				return;

			shortCutValue = KeysHelper.GetKeyCombination(e.KeyData);
			SetKeyText();
		}

		private readonly KeyCombinationHelper keyCombinationHelper = new KeyCombinationHelper();

		private void GetShortCutKeyCode_KeyDown(object sender, KeyEventArgs e)
		{
			keyCombinationHelper.SetKeyDown(e.KeyData);
		}

		private const string None = "{brak}";

		private void SetKeyText()
		{
			textBoxKeyCode.Text = shortCutValue.Key == Keys.None && shortCutValue.Modifiers == Modifiers.None
				? None
				: shortCutValue.ToString();
		}

		private void buttonClear_Click(object sender, EventArgs e)
		{
			shortCutValue = new KeyCombination();
			SetKeyText();
		}

		private void GetShortCutKeyCode_Load(object sender, EventArgs e)
		{
			//Stop Global Keys when setting new one
			ShortCutsWatcher.StopWatch();
		}

		private void GetShortCutKeyCode_FormClosed(object sender, FormClosedEventArgs e)
		{
			//Start Global Keys when on close
			ShortCutsWatcher.StartWatch();
		}
	}
}