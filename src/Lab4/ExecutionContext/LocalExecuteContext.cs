using System;
using System.IO;
using System.Text.Json;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

public class LocalExecuteContext : IExecuteContext
{
    private string? _rootPath;
    private string? _currentPath;

    public LocalExecuteContext(string rootPath)
    {
        if (!Path.IsPathRooted(rootPath))
            throw new InvalidOperationException("a non-absolute path in the attached file system was passed");
        _rootPath = rootPath;
        _currentPath = rootPath;
    }

    public OperationResult Disconnect()
    {
        _rootPath = null;
        _currentPath = null;
        return new OperationResult.Success(this);
    }

    public OperationResult TreeGoTo(string path)
    {
        string fullPath = GetFullPath(path);
        if (fullPath.Length == 0 || !Path.Exists(fullPath))
            return new OperationResult.ExecutionError("the specified directory does not exist");

        _currentPath = fullPath;
        return new OperationResult.Success(this);
    }

    public OperationResult TreeList(IOutputMode outputMode, int depth)
    {
        if (_currentPath is null)
            return new OperationResult.ExecutionError("the specified directory does not exist");
        TreeList(outputMode, depth, 0, _currentPath);

        return new OperationResult.Success(this);
    }

    public OperationResult ShowFile(IOutputMode outputMode, string filename)
    {
        string fullPathFileName = GetFullPath(filename);

        if (fullPathFileName.Length == 0 || !File.Exists(fullPathFileName))
            return new OperationResult.ExecutionError("the specified file does not exist or is a directory");

        string content = File.ReadAllText(filename);
        outputMode.Output(content);
        return new OperationResult.Success(this);
    }

    public OperationResult MoveFile(string sourcePath, string destinationPath)
    {
        string sourceFullPath = GetFullPath(sourcePath);
        string destinationFullPath = GetFullPath(destinationPath);
        if (File.Exists(sourceFullPath) is false)
            return new OperationResult.ExecutionError("the specified file does not exist");
        if (Directory.Exists(destinationFullPath) is false)
            return new OperationResult.ExecutionError("the specified directory does not exist");

        File.Move(sourceFullPath, Path.Combine(destinationFullPath, Path.GetFileName(sourceFullPath)));
        return new OperationResult.Success(this);
    }

    public OperationResult CopyFile(string sourcePath, string destinationPath)
    {
        string sourceFullPath = GetFullPath(sourcePath);
        string destinationFullPath = GetFullPath(destinationPath);
        if (File.Exists(sourceFullPath) is false)
            return new OperationResult.ExecutionError("the specified file does not exist");
        if (Directory.Exists(destinationFullPath) is false)
            return new OperationResult.ExecutionError("the specified directory does not exist");

        File.Copy(sourceFullPath, Path.Combine(destinationFullPath, Path.GetFileName(sourceFullPath)));
        return new OperationResult.Success(this);
    }

    public OperationResult FileDelete(string fileName)
    {
        string fullPath = GetFullPath(fileName);

        if (!File.Exists(fullPath))
            return new OperationResult.ExecutionError("the specified file does not exist");

        File.Delete(fullPath);
        return new OperationResult.Success(this);
    }

    public OperationResult RenameFile(string filePath, string newFileName)
    {
        string fullPath = GetFullPath(filePath);

        if (!File.Exists(fullPath))
            return new OperationResult.ExecutionError("the specified file does not exist");

        string? directoryFullPath = Path.GetDirectoryName(fullPath);
        if (directoryFullPath != null)
        {
            string newFilePath = Path.Combine(directoryFullPath, newFileName);
            File.Move(fullPath, newFilePath);
            return new OperationResult.Success(this);
        }

        File.Move(fullPath, newFileName);

        return new OperationResult.Success(this);
    }

    private string GetFullPath(string path)
    {
        if (Path.IsPathRooted(path))
            return path;
        return _currentPath == null ? string.Empty : Path.Combine(_currentPath, path);
    }

    private void TreeList(IOutputMode outputMode, int depth, int currentDepth, string path)
    {
        if (currentDepth >= depth)
            return;
        if (System.IO.Directory.Exists(path) is false) return;

        string json = File.ReadAllText("C:\\Users\\valer\\RiderProjects\\nek00oo\\src\\Lab4\\Icons.json");
        JsonIcons? icons = JsonSerializer.Deserialize<JsonIcons>(json);
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string[] directories = System.IO.Directory.GetFileSystemEntries(path);
        outputMode.Output($"{new string(' ', currentDepth * 5)}|");
        foreach (string directory in directories)
        {
            string? icon;
            if (System.IO.Directory.Exists(directory)) icon = icons?.Folder;
            else if (File.Exists(directory)) icon = icons?.File;
            else icon = "??";
            try
            {
                outputMode.Output($"{new string(' ', currentDepth * 5)}|_{icon}[{Path.GetFileName(directory)}]");
                TreeList(outputMode, depth, currentDepth + 1, directory);
            }
            catch (UnauthorizedAccessException)
            {
                outputMode.Output($"{new string(' ', (currentDepth + 1) * 5)}{icons?.NoAccess}  No access for {Path.GetFileName(directory)} directory");
            }
        }
    }
}