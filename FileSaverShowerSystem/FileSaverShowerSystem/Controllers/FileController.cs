using FileSaverShowerSystem.Abstractions;
using FileSaverShowerSystem.DTOs;
using FileSaverShowerSystem.Response;
using Microsoft.AspNetCore.Mvc;

namespace FileManagerService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly IFileManagerService _fileManagerService;

    public FileController(IFileManagerService fileManagerService)
    {
        _fileManagerService = fileManagerService;
    }
    
    [HttpPost]
    public async Task<ActionResult<FileResponse>> CreateFileAsync([FromBody] FileDto dto)
    {
        var fileName = $"{Guid.NewGuid().ToString()}.{dto.Extension}";
        var response = new FileResponse
        {
            ImagePath = await _fileManagerService.WriteFileAsync(dto.Body, fileName, new CancellationToken())
        };

        if (string.IsNullOrEmpty(response.ImagePath))
        {
            return BadRequest("Не удалось записать файл.");
        }

        return Ok(response);
    }
}