using LoggerAsync.Enums;
using LoggerAsync.EventHandlers;
using LoggerAsync.Services.Abstractions;

namespace LoggerAsync;

public class Startup
{
    private const int IterationCount = 25;
    
    private readonly ILoggerService _loggerService;
    private readonly LogBackupEventHandler _backupHandler;

    public Startup(
        ILoggerService loggerService,
        LogBackupEventHandler backupHandler)
    {
        _loggerService = loggerService;
        _backupHandler = backupHandler;
        
        _loggerService.BackupSignal += _backupHandler.HandleBackup;
    }
    
    public async void Start()
    {
        try
        {
            await Task.WhenAll(FirstMethod(), SecondMethod());

            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private async Task FirstMethod()
    {
        await Parallel.ForAsync(0, IterationCount, async (i, ct) =>
        {
            _loggerService.Log(LogType.Info, "Custom info message");
            await Task.Delay(TimeSpan.FromMilliseconds(1), ct);
        });
    }
    
    private async Task SecondMethod()
    {
        await Parallel.ForAsync(0, IterationCount, async (i, ct) =>
        {
            _loggerService.Log(LogType.Warning, "Custom warning message");
            await Task.Delay(TimeSpan.FromMilliseconds(1), ct);
        });
    }
}