using System.Drawing;
using System.Windows.Forms;

namespace KeyFreak.Base
{
	/// <summary>
	/// Interfejs komendy, podstawowa konfiguracja potrzebna do opisania komendy.
	/// </summary>
	public interface IKeyCommand
	{
		/// <summary>
		/// Identyfikator komendy.
		/// </summary>
		string Id { get; set; }
		/// <summary>
		/// Klawisz odpowiedzialny z wywołania/nawigacji do komendy.
		/// </summary>
		Keys KeyCode { get; }
		/// <summary>
		/// Opis komedny widoczny na liście.
		/// </summary>
		string Description { get; }
		/// <summary>
		/// Graficzna reprezentacja komendy, widoczna na liście.
		/// </summary>
		Image Icon { get; }
	}
}