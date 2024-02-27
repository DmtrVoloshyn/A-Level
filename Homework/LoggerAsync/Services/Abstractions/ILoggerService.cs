using LoggerAsync.Enums;

namespace LoggerAsync.Services.Abstractions;

public interface ILoggerService
{
    public event EventHandler<int>? BackupSignal;
    Task Log(LogType logType, string massage);
}