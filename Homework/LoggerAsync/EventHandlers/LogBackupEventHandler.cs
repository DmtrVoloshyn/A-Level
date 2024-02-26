using LoggerAsync.Services.Abstractions;

namespace LoggerAsync.EventHandlers;

public class LogBackupEventHandler
{
    private readonly IFileService _fileService;
    private int _backupLength;
    
    public LogBackupEventHandler(IFileService fileService)
    {
        _fileService = fileService;
    }
    
    public void HandleBackup(object? sender, int backupLength)
    {
        _backupLength += backupLength; 
        _fileService.CreateBackup(_backupLength);
    }
}