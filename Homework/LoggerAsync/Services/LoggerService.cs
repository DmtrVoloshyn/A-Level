using LoggerAsync.Enums;
using LoggerAsync.Options;
using LoggerAsync.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace LoggerAsync.Services;

public class LoggerService : ILoggerService
{
    public event EventHandler<int>? BackupSignal;
    
    private readonly LoggerOptions _loggerOptions;
    private readonly IFileService _fileService;
    private readonly SemaphoreSlim _semaphoreSlim;
    private readonly string _logFilePath;
    
    private int _logCounter;
    
    public LoggerService(IOptions<LoggerOptions> loggerOptions, IFileService fileService)
    {
        _fileService = fileService;
        _loggerOptions = loggerOptions.Value;
        _semaphoreSlim = new(1);
        
        var logFileName = _loggerOptions.Logs.LogFileName;
        var logDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _loggerOptions.Logs.LogDirectoryName);
        
        _logFilePath = Path.Combine(logDirectoryPath, logFileName);
    }

    public async Task Log(LogType logType, string message)
    {
        var log = $"{DateTime.UtcNow} {logType} {message}";

        await _semaphoreSlim.WaitAsync();
        
        Console.WriteLine(log); 
        await _fileService.WriteToFileAsync(log, _logFilePath);
        
        _logCounter++;
        if (_logCounter == _loggerOptions.Backup.BackupSize) 
        { 
            BackupSignal?.Invoke(this, _logCounter); 
            _logCounter = 0;
        } 
        
        _semaphoreSlim.Release();
    }
}