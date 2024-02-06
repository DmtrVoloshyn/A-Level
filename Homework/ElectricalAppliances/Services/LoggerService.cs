using ElectricalAppliances.Enums;
using ElectricalAppliances.Options;
using Microsoft.Extensions.Options;

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
            SaveLog(log);
        }

        private void SaveLog(string log)
        {
            try
            {
                using (StreamWriter streamWriter = File.AppendText(_loggerOptions.Path))
                {
                    streamWriter.Write(log);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to log: {ex.Message}");
            }
        }
    }
}

