using Logger.Services;

public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _fileName;

    public FileService(string directoryPath)
    {
        _directoryPath = directoryPath;

        _fileName = $"{DateTime.Now:MM.dd.yyyy HH.mm.ss.fff tt}.txt";

        string filePath = Path.Combine(_directoryPath, _fileName);

        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
        }

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }

        var files = Directory.GetFiles(_directoryPath);
        if (files.Length > 3)
        {
            var orderedFiles = files.OrderBy(f => new FileInfo(f).CreationTime).ToArray();
            File.Delete(orderedFiles[0]);
        }
    }

    public void WriteToFile(string data)
    {
        string filePath = Path.Combine(_directoryPath, _fileName);

        using (StreamWriter streamWriter = new(filePath, true))
        {
            streamWriter.WriteLine(data);
        }
    }
}
