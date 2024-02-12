using FileSaverShowerSystem.Abstractions;
using FileSaverShowerSystem.Options;
using Microsoft.Extensions.Options;

namespace FileSaverShowerSystem.Service;

public class FileManagerService : IFileManagerService
{
    private readonly IOptions<LocalFileManagerOptions> _options;

    public FileManagerService(IOptions<LocalFileManagerOptions> options)
    {
        _options = options;
    }

    public async Task<string> WriteFileAsync(string file, string name, CancellationToken cancellationToken)
    {
        try
        {
            if (file.Length == 0)
            {
                return string.Empty;
            }
            var fileBody = Convert.FromBase64String(file);
            var filePath = Path.Combine(_options.Value.DefaultPath, name);
            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await fileStream.WriteAsync(fileBody, cancellationToken);
            return $"{_options.Value.Host}/{name}";
        }
        catch (Exception e)
        {
            return e.ToString();
        }
    }

    public async Task<string> GetFileAsync(string filePath, CancellationToken cancellationToken)
    {
        if (!IsFileExist(filePath))
        {
            return string.Empty;
        }
        
        var fileBytes = await File.ReadAllBytesAsync(filePath, cancellationToken);
        return Convert.ToBase64String(fileBytes);
    }

    public void DeleteFile(string path)
    {
        File.Delete(path);
    }

    public bool IsFileExist(string path)
    {
        return File.Exists(path);
    }
}