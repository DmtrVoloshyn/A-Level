namespace LoggerAsync.Services.Abstractions;

public interface IFileService
{
    void WriteToFile(string data, string path);
    Task WriteToFileAsync(string data, string path); 
    void CreateBackup(int backupLength);
}