using log4net;
using System;

namespace KeyFreak.Tools
{
	public static class LogManager
	{
		public static ILog Logger(Type type)
		{
			return log4net.LogManager.GetLogger(type);
		}
	}
}
