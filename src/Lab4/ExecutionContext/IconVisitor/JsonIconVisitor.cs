using System;
using System.IO;
using System.Text.Json;

namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.IconVisitor;

public class JsonIconVisitor : IIconsVisitor
{
    private readonly JsonIcons? _icons;

    // "C:\\Users\\valer\\RiderProjects\\nek00oo\\src\\Lab4\\Icons.json"
    public JsonIconVisitor(string path)
    {
        string json = File.ReadAllText(path);
        _icons = JsonSerializer.Deserialize<JsonIcons>(json);
        Console.OutputEncoding = System.Text.Encoding.UTF8;
    }

    public string VisitFolderIcon() => _icons?.Folder ?? string.Empty;

    public string VisitFileIcon() => _icons?.File ?? string.Empty;

    public string VisitNoAccessIcon() => _icons?.NoAccess ?? string.Empty;
}