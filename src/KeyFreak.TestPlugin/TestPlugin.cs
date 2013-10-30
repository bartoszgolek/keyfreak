using KeyFreak.Base;
using System.Collections.Generic;

namespace KeyFreak.TestPlugin
{
	public class TestPlugin : IPlugin
	{
		public string NameSpace
		{
			get { return "test"; }
		}

		public IKeyCommand CreateCommand(string commandName, KeyCommandConfig config)
		{
			switch (commandName)
			{
				case "TestCommand":
					return new TestCommand
					{
						Id = config.Id,
						Description = config.Description,
						Icon = config.Icon,
						KeyCode = config.KeyCode,
						Parameters = config.Parameters
					};
			}

			return null;
		}


		public KeyCommandConfigurationControl CreateCommandConfigurationControl(string commandName)
		{
			switch (commandName)
			{
				case "TestCommand":
					return null;
			}

			return null;
		}


		public IList<string> CommandsList
		{
			get
			{
				return new List<string> 
				{
					"TestCommand"
				};
			}
		}
	}
}