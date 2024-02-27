using LoggerAsync.Enums;
using LoggerAsync.Helpers;
using LoggerAsync.Services.Abstractions;

namespace LoggerAsync.Services;

public class LoggerService : ILoggerService
{
    public event EventHandler<int>? BackupSignal;
    
    private readonly IFileService _fileService;
    private readonly SemaphoreSlim _semaphoreSlim;
    
    private int _logCounter;
    
    public LoggerService(IFileService fileService)
    {
        _fileService = fileService;
        _semaphoreSlim = new(1);
    }

    public async Task Log(LogType logType, string message)
    {
        var log = $"{DateTime.UtcNow} {logType} {message}";
        var backupSize = LoggerHelper.GetBackupSize();

        await _semaphoreSlim.WaitAsync();
        
        Console.WriteLine(log); 
        await _fileService.WriteToFileAsync(log, LoggerHelper.GetLogFilePath());
        
        _logCounter++;
        if (_logCounter == backupSize) 
        { 
            BackupSignal?.Invoke(this, backupSize);
            _logCounter = 0;
        } 
        
        _semaphoreSlim.Release();
    }
}