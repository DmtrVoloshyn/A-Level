namespace LoggerAsync.Services.Abstractions;

public interface IFileService
{
    Task WriteToFile(string data);
    public void CreateBackup();
}