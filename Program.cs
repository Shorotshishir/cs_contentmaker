using System.Text.Json;
using Microsoft.AspNetCore.StaticFiles;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var dir = "";

        if (args.Length < 1)
        {
            return;
        }
        else
        {
            if (args[0] == ".")
            {
                dir = Environment.CurrentDirectory + "/";
            }
            else
            {
                // TODO : check if string is a valid path
                // TODO : set valid path to dir
                return;
            }
        }

        var dirInfo = new DirectoryInfo(dir);
        var files = dirInfo.EnumerateFiles();
        var contentList = new List<Content>();

        var provider = new FileExtensionContentTypeProvider();
        foreach (var f in files)
        {
            DateTimeOffset creationDate = f.CreationTimeUtc.ToUniversalTime();
            contentList.Add(new Content
            {
                Id = Guid.NewGuid().ToString(),
                Filename = f.Name,
                FilePath = f.FullName,
                Extension = f.Extension,
                Size = f.Length,
                CreationTime = creationDate.ToUnixTimeMilliseconds().ToString(),
                ContentType = GetMimeType(provider, f.FullName)
            });
        }
        var contents = new Contents
        {
            ContentList = contentList
        };
        await WriteJson(contents);
    }

    private static async Task WriteJson(Contents contents)
    {
        await File.WriteAllTextAsync(
                    "content_list.json",
                    JsonSerializer.Serialize(contents, new JsonSerializerOptions
                    {
                        WriteIndented = true,
                    })
                );
    }

    private static string GetMimeType(FileExtensionContentTypeProvider provider, string fileName)
    {

        if (!provider.TryGetContentType(fileName, out var contentType))
        {
            contentType = "application/octet-stream";
        }
        return contentType;
    }
}