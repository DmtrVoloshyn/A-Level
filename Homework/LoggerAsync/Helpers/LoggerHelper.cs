using LoggerAsync.Options;

namespace LoggerAsync.Helpers;

public static class LoggerHelper
{
    private static LoggerOptions? _loggerOptions;

    public static void Configure(LoggerOptions loggerOptions)
    {
        _loggerOptions = loggerOptions;
    }

    public static string GetBackupDirPath() => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _loggerOptions?.Backup.BackupsDirectoryName ?? "");

    public static string GetLogDirPath() => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _loggerOptions?.Logs.LogDirectoryName ?? "");

    private static string GetLogFileName() => _loggerOptions?.Logs.LogFileName ?? "";

    public static string GetLogFilePath() => Path.Combine(GetLogDirPath(), GetLogFileName());

    public static int GetBackupSize() => _loggerOptions?.Backup.BackupSize ?? 0;
}