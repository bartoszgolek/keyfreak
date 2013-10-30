using System.Collections.Generic;

namespace KeyFreak.Base
{
	/// <summary>
	/// Interfejs komendy która może zawierać grupę innych komend.
	/// </summary>
	public interface IKeyCommandGroup : IKeyCommand
	{
		/// <summary>
		/// Lista komend należących do grupy.
		/// </summary>
		IList<IKeyCommand> SubCommands { get; }
	}
}