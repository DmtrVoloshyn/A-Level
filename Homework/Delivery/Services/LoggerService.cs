using Delivery.Config;
using Delivery.Enums;
using Delivery.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace Delivery.Services
{
	public class LoggerService : ILoggerService
	{
        private readonly LogOption _logOption;
        private readonly List<string> _logs;
        public LoggerService(IOptions<LogOption> options)
		{
            _logOption = options.Value;
            _logs = new List<string>();
		}

        public void Log(LogType logType, string message)
        {
            var log = $"{DateTime.UtcNow}:{nameof(logType)}:{message}";
            Console.WriteLine(log);
            _logs.Add(log);

            try
            {
                using (StreamWriter sw = File.AppendText(_logOption.Path))
                {
                    sw.Write(log);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to log: {ex.Message}");
            }

        }
    }
}

