using System;
using Delivery.Enums;

namespace Delivery.Services.Abstractions
{
	public interface ILoggerService
	{
		void Log(LogType logType, string message);
	}
}

