namespace LoggerAsync.Services.Abstractions;

public interface IFileService
{
    Task WriteToFile(string data); 
    void CreateBackup(int backupLength);
}