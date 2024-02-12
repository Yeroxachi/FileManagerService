namespace FileSaverShowerSystem.Options;

public record LocalFileManagerOptions
{
    public required string DefaultPath { get; init; }
    public required string Host { get; init; }
}