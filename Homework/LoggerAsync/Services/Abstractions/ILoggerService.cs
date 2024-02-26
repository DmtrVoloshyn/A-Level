using LoggerAsync.Enums;

namespace LoggerAsync.Services.Abstractions;

public interface ILoggerService
{
    public event EventHandler<int>? BackupSignal; 
    void Log(LogType logType, string massage);
}