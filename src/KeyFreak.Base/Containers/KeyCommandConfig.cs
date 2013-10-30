using System.Drawing;
using System.Windows.Forms;

namespace KeyFreak.Base
{
	/// <summary>
	/// Konfiguracja komendy odczytana z pliku konfiguracji.
	/// Zawiera dane elementu XML. Przekazywana do faabryki podczas instancjonowania komend.
	/// </summary>
	public class KeyCommandConfig
	{
		/// <summary>
		/// Unikalny identyfikator komendy.
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// Parametry komendy.
		/// </summary>
		public string Parameters { get; set; }
		/// <summary>
		/// Obraz przypisany do komendy.
		/// </summary>
		public Image Icon { get; set; }
		/// <summary>
		/// Opis komendy.
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// Klawuisz wywołania.
		/// </summary>
		public Keys KeyCode { get; set; }
	}
}