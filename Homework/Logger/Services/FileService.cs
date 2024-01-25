namespace Logger.Services
{
    public class FileService : IFileService
    {
        private readonly string _directoryPath;

        public FileService(string directoryPath)
        {
            _directoryPath = directoryPath;

            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
        }

        public void WriteToFile(string data)
        {
            var files = Directory.GetFiles(_directoryPath).ToList();

            if (files.Count > 3)
            {
                string oldestFile = files.OrderBy(f => File.GetCreationTime(f)).First();
                File.Delete(oldestFile);
            }

            string fileName = $"{DateTime.Now:MM/dd/yyyy HH:mm:ss.fff tt}.txt";

            string filePath = Path.Combine(_directoryPath, fileName);

            using (FileStream fileStream = File.Create(filePath))
            {
                using StreamWriter writer = new StreamWriter(fileStream);
                writer.WriteLine(data);
            }
        }
    }
}