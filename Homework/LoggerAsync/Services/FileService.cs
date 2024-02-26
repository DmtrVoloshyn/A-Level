using LoggerAsync.Options;
using LoggerAsync.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace LoggerAsync.Services
{
    public class FileService : IFileService
    {
        private readonly SemaphoreSlim _semaphoreSlim;
        private readonly string? _backupDirectoryPath;
        private readonly string? _logDirectoryPath;
        private readonly string _fileName;
        private readonly string _filePath;

        public FileService(IOptions<LoggerOptions> loggerOptions)
        {
            _logDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, loggerOptions.Value.LogDirectoryName);
            _backupDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                loggerOptions.Value.BackupsDirectoryName);
            
            _fileName = "log.txt";
            _filePath = Path.Combine(_logDirectoryPath, _fileName);
            
            InitializeDirectoryAsync().Wait();
            
            _semaphoreSlim = new SemaphoreSlim(5);
        }

        private async Task InitializeDirectoryAsync()
        {
            if (!Directory.Exists(_logDirectoryPath))
            {
                await CreateDirectoryAsync();
            }
        }

        private async Task CreateDirectoryAsync()
        {
            try
            {
                await Task.Run(() => Directory.CreateDirectory(_logDirectoryPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating directory: {ex.Message}");
            }
        }

        public async Task WriteToFile(string data)
        {
            await _semaphoreSlim.WaitAsync();
            
            try
            {
                if (!File.Exists(_filePath))
                {
                    File.Create(_filePath).Close();
                }

                await using var writer = new StreamWriter(_filePath, true);
                await writer.WriteLineAsync(data);
                await writer.FlushAsync();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public void CreateBackup(int backupLength)
        {
            var backupFileName = $"{DateTime.UtcNow:MM.dd.yyyy HH.mm.ss.fff tt}_backup.txt";
            var backupFilePath = Path.Combine(_backupDirectoryPath, backupFileName);
            
            try
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    var allLines = GetLines(backupLength, reader);
                }

                File.Copy(_filePath, backupFilePath);
                
                Console.WriteLine($"Backup created at: {backupFilePath}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error creating backup: {e.Message}");
            }
        }

        private static IEnumerable<string> GetLines(int backupLength, StreamReader reader)
        {
            for (int i = 0; i < backupLength; i++)
            {
                var item = reader.ReadLine();

                if (item != null)
                    yield return item;
            }
        }
    }
}