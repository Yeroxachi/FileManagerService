namespace FileSaverShowerSystem.DTOs;

public record FileDto
{
    public required string Extension { get; init; }
    public required string Body { get; init; }
}