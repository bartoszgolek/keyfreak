using KeyFreak.Base;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KeyFreak.Commands
{
	public class SequenceCommand : IRunableKeyCommand, IKeyCommandGroup
	{
		/// <summary>
		/// Id komendy z konfiguracji
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// Klawisz przypisany do komendy w konfiguracji.
		/// </summary>
		public Keys KeyCode { get; set; }
		/// <summary>
		/// Opis komendy z konfiguracji
		/// </summary>
		public string Description { get; set; }
		
		public string Parameters { get; set; }

		public void Run(KeyCommandContext context)
		{
			foreach (IKeyCommand command in SubCommands)
			{
				var runableCommand = command as IRunableKeyCommand;
				if (runableCommand != null)
					runableCommand.Run(context);
			}
		}

		private Image icon = Properties.Resources.set;
		/// <summary>
		/// Ikona przekazana z konfiguracji. Posiada ikonę domyślną.
		/// </summary>
		public Image Icon
		{
			get
			{
				return icon;
			}
			set
			{
				icon = value ?? Properties.Resources.sequence;
			}
		}

		private readonly List<IKeyCommand> subCommands = new List<IKeyCommand>();
		/// <summary>
		/// Komendy należące do grupy. Lista tworzona na podstawie paraemtry
		/// parent komend podrzednych z konfiguracji.
		/// </summary>
		public IList<IKeyCommand> SubCommands
		{
			get { return subCommands; }
		}
	}
}
