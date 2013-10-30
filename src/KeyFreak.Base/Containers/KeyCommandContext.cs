using System;

namespace KeyFreak.Base
{
	/// <summary>
	/// Klasa dostarczająca kontekstu wywołania metody np. uchwyt okna aktywnego w chwili uruchomineia komendy
	/// </summary>
	public class KeyCommandContext
	{
		/// <summary>
		/// Na razie nie działa. Ma przekazywać okno aktywne w podczas wywołania KeyFreak.
		/// </summary>
		public IntPtr ActiveWindow { get; set; }
	}
}