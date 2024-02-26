using LoggerAsync.Services.Abstractions;

namespace LoggerAsync.EventHandlers;

public class LogBackupEventHandler
{
    private readonly IFileService _fileService;
    
    public LogBackupEventHandler(IFileService fileService)
    {
        _fileService = fileService;
    }
    
    public void HandleBackup(object? sender, EventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("This text is in green!");
        Console.ResetColor();

        _fileService.CreateBackup();
    }
}