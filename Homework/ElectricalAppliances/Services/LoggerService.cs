using ElectricalAppliances.Enums;
using ElectricalAppliances.Options;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace ElectricalAppliances.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly LogOption _loggerOptions;

        public LoggerService(IOptions<LogOption> loggerOptions)
        {
            _loggerOptions = loggerOptions.Value;
        }

        public void Log(LogType logType, string massage)
        {
            var log = $"{DateTime.UtcNow} {logType} {massage}";
            Console.WriteLine(log);
            Debug.WriteLine($"write log to {_loggerOptions.Path}");
        }
    }
}

