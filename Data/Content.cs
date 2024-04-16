public class Content
{
    public string Id { get; set; } = string.Empty;
    public string Filename { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string CreationTime { get; set; } = string.Empty;
    public string Extension { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public long Size { get; set; } = 0L;
}

public class Contents
{
    public required List<Content> ContentList { get; set; } = new List<Content>();
}