using System.Text;
using Homework5;

class Logger
{
    private static Logger? instance;
    private string received_log = "";

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            instance ??= new Logger();
            return instance;
        }
    }

    private static string FormatLog(string logTime, LogLevel logLevel, string logMessage)
    {
        StringBuilder formattedLog = new();

        formattedLog.Append($"{logTime}: ");
        formattedLog.Append($"{logLevel}: ");
        formattedLog.Append(logMessage);

        return formattedLog.ToString();
    }

    private static void ChangeLogColor(LogLevel loglevel)
    {
        _ = loglevel switch
        {
            LogLevel.Info => Console.ForegroundColor = ConsoleColor.Green,
            LogLevel.Warning => Console.ForegroundColor = ConsoleColor.DarkYellow,
            LogLevel.Error => Console.ForegroundColor = ConsoleColor.DarkRed,
            _ => throw new NotImplementedException()
        };
    }


    public void Log(LogLevel logLevel, string logMessage)
    {
        ChangeLogColor(logLevel);

        string logTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        string formattedLog = FormatLog(logTime, logLevel, logMessage);

        Console.WriteLine(formattedLog);
        received_log += formattedLog + "\n";
    }

    public void WriteLogsToFile()
    {
        File.WriteAllText("log.txt", received_log);
    }
}
