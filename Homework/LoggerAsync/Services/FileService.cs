using LoggerAsync.Options;
using LoggerAsync.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace LoggerAsync.Services
{
    public class FileService : IFileService
    {
        private readonly string _backupDirectoryPath;
        private readonly string _logFilePath;
        
        public FileService(IOptions<LoggerOptions> loggerOptions)
        {
            var loggerOptions1 = loggerOptions.Value;
        
            var logFileName = loggerOptions1.Logs.LogFileName;
            var logDirectoryPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, 
                loggerOptions1.Logs.LogDirectoryName);
            
            _backupDirectoryPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                loggerOptions.Value.Backup.BackupsDirectoryName);
            _logFilePath = Path.Combine(logDirectoryPath, logFileName);
            
            InitializeDirectoryAsync(logDirectoryPath).Wait();
        }

        private async Task InitializeDirectoryAsync(string path)
        {
            if (!Directory.Exists(path))
            {
                await CreateDirectoryAsync(path);
            }
        }

        private static async Task CreateDirectoryAsync(string path)
        {
            try
            {
                await Task.Run(() => Directory.CreateDirectory(path));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating directory: {ex.Message}");
            }
        }

        public void WriteToFile(string data, string path)
        {
            try
            {
                using var writer = new StreamWriter(path, true);
                writer.WriteLine(data);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task WriteToFileAsync(string data, string path)
        {
            CreateFile(path);
            
            await using var writer = new StreamWriter(path, true); 
            await writer.WriteLineAsync(data); 
            await writer.FlushAsync();
        }

        private static void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        public void CreateBackup(int backupLength)
        {
            var backupFileName = $"{DateTime.UtcNow:MM.dd.yyyy HH.mm.ss.fff tt zz}_backup.txt";
            var backupFilePath = Path.Combine(_backupDirectoryPath, backupFileName);
            
            try
            {
                using StreamReader reader = new StreamReader(_logFilePath);
                    var allLines = GetLines(backupLength, reader);

                    allLines.ToList().ForEach(line => WriteToFile(line, backupFilePath));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error creating backup: {e.Message}");
            }
        }

        private static IEnumerable<string> GetLines(int backupLength, StreamReader reader)
        {
            for (var i = 0; i < backupLength; i++)
            {
                var item = reader.ReadLine();

                if (item != null)
                    yield return item;
            }
        }
    }
}