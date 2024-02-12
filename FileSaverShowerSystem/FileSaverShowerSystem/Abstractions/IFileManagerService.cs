namespace FileSaverShowerSystem.Abstractions;

public interface IFileManagerService
{
    Task<string> WriteFileAsync(string file, string name, CancellationToken cancellationToken = default);
    Task<string> GetFileAsync(string filePath, CancellationToken cancellationToken = default);
    void DeleteFile(string path);
    bool IsFileExist(string path);
}