using System.Diagnostics;
using Logger.Config;
using Logger.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace Logger.Services
{
	public class LoggerService : ILoggerService
	{
        private readonly LoggerOption _loggerOption;
        private readonly IFileService _fileService;

        public LoggerService(IOptions<LoggerOption> loggerOption, IFileService fileService)
		{
            _loggerOption = loggerOption.Value;
            _fileService = fileService;
        }

        public void Log(LogLevel logLevel, string logMessage)
        {
            var logTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var formattedLog = $"{logTime} {logLevel} {logMessage}";

            Console.WriteLine(formattedLog);
            Debug.WriteLine($"write log to {_loggerOption.Path}");

            _fileService.WriteToFile(formattedLog);
        }
    }
}
