using LoggerAsync.Helpers;
using LoggerAsync.Services.Abstractions;

namespace LoggerAsync.Services
{
    public class FileService : IFileService
    {
        public FileService()
        {
            var logDirectoryPath = LoggerHelper.GetLogDirPath();
            
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
            var backupFilePath = Path.Combine(LoggerHelper.GetBackupDirPath(), backupFileName);
            
            try
            {
                using StreamReader reader = new StreamReader(LoggerHelper.GetLogFilePath());
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