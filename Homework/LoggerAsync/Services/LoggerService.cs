using LoggerAsync.Enums;
using LoggerAsync.Options;
using LoggerAsync.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace LoggerAsync.Services;

public class LoggerService : ILoggerService
{
    public event EventHandler? BackupSignal; 
    
    private readonly LoggerOptions _loggerOptions;
    private readonly IFileService _fileService;
    private readonly object _lockObject = new();
    private int _logCounter;
    
    public LoggerService(IOptions<LoggerOptions> loggerOptions, IFileService fileService)
    {
        _loggerOptions = loggerOptions.Value;
        _fileService = fileService;
    }

    public void Log(LogType logType, string message)
    {
        var log = $"{DateTime.UtcNow} {logType} {message}";
        Console.WriteLine(log);

        _fileService.WriteToFile(log);

        lock (_lockObject)
        {
            _logCounter++;
        
            if (_logCounter % _loggerOptions.BackupSize == 0)
                BackupSignal?.Invoke(this, EventArgs.Empty);
        }
    }
}