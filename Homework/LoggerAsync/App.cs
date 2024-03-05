using LoggerAsync.Enums;
using LoggerAsync.EventHandlers;
using LoggerAsync.Services.Abstractions;

namespace LoggerAsync;

public class App
{
    private const int IterationCount = 250;
    
    private readonly ILoggerService _loggerService;

    public App(
        ILoggerService loggerService,
        LogBackupEventHandler backupHandler)
    {
        _loggerService = loggerService;
        _loggerService.BackupSignal += backupHandler.Handle;
    }
    
    public async Task Start()
    {
        try
        {
            await Task.WhenAll(ProcessLog(LogType.Info), ProcessLog(LogType.Warning));
        }
        catch (Exception e)
        {
            throw new Exception($"Error when starting app: {e}");
        }
        
        Console.ReadLine();
    }
    
    private async Task ProcessLog(LogType logType)
    {
        await Parallel.ForAsync(default, IterationCount, async (_, ct) =>
        {
            await _loggerService.Log(logType, "Custom message");
            await Task.Delay(TimeSpan.Zero, ct);
        });
    }
}