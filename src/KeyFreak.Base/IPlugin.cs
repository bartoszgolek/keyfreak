using System.Collections.Generic;
namespace KeyFreak.Base
{
	/// <summary>
	/// Główny interfejs plugin'ów. Dostarcza fabrykę komend.
	/// Określa też Namespace w konfiguracji definiujący odwołanie do fabryki.
	/// </summary>
	public interface IPlugin
	{
		/// <summary>
		/// NameSpace komendy. Każdy plugin powinien dostarczać unikalny NameSpace.
		/// </summary>
		string NameSpace { get; }

		/// <summary>
		/// Lista komend dostarczanych przez plugin.
		/// </summary>
		IList<string> CommandsList { get; }

		/// <summary>
		/// Metoda fabryki zwracająca instancję komendy.
		/// Jeżeli plugin nie zawiera komendy o podanej nazwie to metoda powinna dla niej zwracać <c>NULL</c>
		/// </summary>
		/// <param name="commandName">Nazwa komendy.</param>
		/// <param name="config">Konfiguracja komendy z pliku XML</param>
		/// <returns>Instancja komendy</returns>
		IKeyCommand CreateCommand(string commandName, KeyCommandConfig config);

		/// <summary>
		/// Metoda zwracająca kontrolkę pozwalającą na konfigurację komendy z poziomu UI.
		/// Jeżeli komenda nie wymaga konfiguracji to metoday powinna dla niej zwracać <c>NULL</c>
		/// </summary>
		/// <param name="commandName">Nazwa komendy.</param>
		/// <returns></returns>
		KeyCommandConfigurationControl CreateCommandConfigurationControl(string commandName);
	}
}