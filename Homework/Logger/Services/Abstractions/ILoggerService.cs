namespace Logger.Services.Abstractions
{
	public interface ILoggerService
    {
        void Log(LogLevel logLevel, string logMessage);
    }
}

