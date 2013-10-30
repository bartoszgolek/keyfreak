using System;
using System.Windows.Forms;

namespace KeyFreak.Base
{
	/// <summary>
	/// Abstrakcyjna kontrola konfiguracji komendy
	/// </summary>
	public partial class KeyCommandConfigurationControl : UserControl
	{
		/// <summary>
		/// Konstruktor kontrolki.
		/// </summary>
		public KeyCommandConfigurationControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Property zawierające ciąg znaków opisujacy parametry komendy.
		/// Ciąg ten zostanie zapisany do XML konfiguracji, a następnie przekazany do komendy, 
		/// podczas tworzenia jej instancji.
		/// </summary>
		/// <returns></returns>
		public virtual string Parameters
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Zdarzenie rzucane gdy parametry komendy zostaną zmienione.
		/// </summary>
		public event EventHandler ParametersChanged;

		/// <summary>
		/// Metoda używan do rzucenia eventu ParametersChanged
		/// </summary>
		protected void OnParametersChanged()
		{
			if (ParametersChanged != null)
				ParametersChanged(this, EventArgs.Empty);
		}
	}
}
