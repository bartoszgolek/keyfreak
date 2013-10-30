using KeyFreak.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyFreak.UI
{
	public class CommandStack : Stack<IKeyCommand>
	{
		public String KeyCombination
		{
			get
			{
				var sb = new StringBuilder();
				foreach (IKeyCommand keyCommand in this)
				{
					if (keyCommand.KeyCode == System.Windows.Forms.Keys.None)
						continue;

					sb.Append(", ");
					sb.Append(keyCommand.KeyCode.ToString());
				}

				var keyComaination = sb.ToString();
				if (keyComaination.Length > 1)
					return sb.ToString().Substring(2);
				return string.Empty;
			}
		}
	}
}