using System.Text;
using Homework5;

class Logger
{
    private static Logger? instance;
    private string receivedLog = "";
    private readonly string logFile = "log.txt";

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            instance ??= new Logger();
            return instance;
        }
    }

    private void SaveLog()
    {
        File.WriteAllText(logFile, receivedLog);
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
            _ => ConsoleColor.White
        };
    }

    private bool IsLogToFile()
    {
        ConsoleKeyInfo confirmationResult;

        do
        {
            confirmationResult = Console.ReadKey();
        }
        while (confirmationResult.Key != ConsoleKey.Y && confirmationResult.Key != ConsoleKey.N);

        return confirmationResult.Key == ConsoleKey.Y;
    }

    public void Log(LogLevel logLevel, string logMessage)
    {
        ChangeLogColor(logLevel);

        string logTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        string formattedLog = FormatLog(logTime, logLevel, logMessage);

        Console.WriteLine(formattedLog);
        receivedLog += formattedLog + "\n";

        Console.ForegroundColor = ConsoleColor.White;
    }

    public void SaveLogWithConfirmation()
    {
        ConsoleKeyInfo confirmationResult;

        Console.Write($"Do you want to save logs to {logFile}? Y/N: ");

        if (IsLogToFile())
        {
            SaveLog();
            Console.WriteLine("\nLogs saved.");
        }
        else
        {
            Console.WriteLine("\nLogs will not be saved.");
        }
    }
}
