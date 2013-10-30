namespace KeyFreak.Base
{
	/// <summary>
	/// Interfejs komendy uruchomieniowej.
	/// Jeżeli komenda implementuje ten interfejs to przy próbie nawigacji do nie zostanei wywołana metoda <c>run</c>
	/// </summary>
	public interface IRunableKeyCommand : IKeyCommand
	{
		/// <summary>
		/// Parawmetry komendu, mogą być przekazane z konfiguracji.
		/// </summary>
		string Parameters { get; set; }

		/// <summary>
		/// Metoda używana do wykonania komendy.
		/// </summary>
		/// <param name="context">Kontekst utworzony podczas naciśnięcia kombinacji klawiszy uaktywniającej KeyFreak.</param>
		void Run(KeyCommandContext context);
	}
}