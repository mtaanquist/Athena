namespace Athena.Models;

class ArchiveTask
{
    public int Id { get; set; }
    public string? ArchiveUrl { get; set; }
    public string? TitleKeywords { get; set; }
    public ArchiveTaskType Type { get; set; }
    public string? OutputTemplate { get; set; }
    public string? StoragePath { get; set; }
    public string? CookieFile { get; set; }
}

enum ArchiveTaskType
{
    Audio,
    Video
}
