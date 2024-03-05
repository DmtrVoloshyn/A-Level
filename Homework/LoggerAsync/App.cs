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
            await Task.WhenAll(FirstMethod(), SecondMethod());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        Console.ReadLine();
    }

    private async Task FirstMethod()
    {
        await ProcessLog(LogType.Warning);
    }

    private async Task SecondMethod()
    {
        await ProcessLog(LogType.Info);
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