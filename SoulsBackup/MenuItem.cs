namespace SoulsBackup;

public record MenuItem
{
    private static int _count = 1;

    public int Id { get; init; } = _count++;

    public required string Command { get; init; }
    public Action<string>? Action { get; set; }
    
    public string Description { get; init; } = string.Empty;
    
    public string Shortcut { get; init; } = string.Empty;
    
    public string Doc { get; init; } = string.Empty;
}