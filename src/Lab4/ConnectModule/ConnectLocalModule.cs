using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConnectModule;

public class ConnectLocalModule : IConnectModule
{
    private string? _rootPath;
    private string? _currentPath;

    public ConnectResult Connect(string path)
    {
        if (!Path.IsPathRooted(path)) return new ConnectResult.ConnectionError();
        _rootPath = path;
        _currentPath = path;
        return new ConnectResult.Success();
    }

    public void Disconnect()
    {
        _rootPath = null;
        _currentPath = null;
    }

    public ConnectResult TreeGoTo(string path)
    {
        string fullPath = GetFullPath(path);
        if (fullPath.Length == 0 || !Path.Exists(fullPath))
            return new ConnectResult.ConnectionError();

        _currentPath = fullPath;
        return new ConnectResult.Success();
    }

    public ConnectResult TreeList(IOutputMode outputMode, int depth)
    {
        if (_currentPath is null) return new ConnectResult.ExecutionError();
        TreeList(outputMode, depth, 0, _currentPath);

        return new ConnectResult.Success();
    }

    public ConnectResult ShowFile(IOutputMode outputMode, string filename)
    {
        string fullPathFileName = GetFullPath(filename);

        if (fullPathFileName.Length == 0 || !Path.Exists(fullPathFileName))
            return new ConnectResult.ExecutionError();
        _currentPath = fullPathFileName;

        string content = File.ReadAllText(filename);
        outputMode.Output(content);
        return new ConnectResult.Success();
    }

    public ConnectResult MoveFile(string sourcePath, string destinationPath)
    {
        string sourceFullPath = GetFullPath(sourcePath);
        string destinationFullPath = GetFullPath(destinationPath);
        if (!File.Exists(sourceFullPath) || !Directory.Exists(destinationFullPath))
            return new ConnectResult.ExecutionError();

        File.Move(sourceFullPath, Path.Combine(destinationFullPath, Path.GetFileName(sourceFullPath)));
        return new ConnectResult.Success();
    }

    public ConnectResult CopyFile(string sourcePath, string destinationPath)
    {
        string sourceFullPath = GetFullPath(sourcePath);
        string destinationFullPath = GetFullPath(destinationPath);
        if (!File.Exists(sourceFullPath) || !Directory.Exists(destinationFullPath))
            return new ConnectResult.ExecutionError();

        File.Copy(sourceFullPath, Path.Combine(destinationFullPath, Path.GetFileName(sourceFullPath)));
        return new ConnectResult.Success();
    }

    public ConnectResult FileDelete(string fileName)
    {
        string fullPath = GetFullPath(fileName);

        if (!File.Exists(fullPath))
            return new ConnectResult.ExecutionError();

        File.Delete(fullPath);
        return new ConnectResult.Success();
    }

    public ConnectResult RenameFile(string filePath, string newFileName)
    {
        string fullPath = GetFullPath(filePath);

        if (!File.Exists(fullPath))
            return new ConnectResult.ExecutionError();

        string? directoryFullPath = Path.GetDirectoryName(fullPath);
        if (directoryFullPath != null)
        {
            string newFilePath = Path.Combine(directoryFullPath, newFileName);
            File.Move(fullPath, newFilePath);
            return new ConnectResult.Success();
        }

        File.Move(fullPath, newFileName);

        return new ConnectResult.Success();
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

        if (Directory.Exists(path) is false) return;
        string[] directories = Directory.GetFileSystemEntries(path);
        outputMode.Output($"{new string(' ', currentDepth * 5)}|");
        foreach (string directory in directories)
        {
            try
            {
                outputMode.Output($"{new string(' ', currentDepth * 5)}|_[{Path.GetFileName(directory)}]");
                TreeList(outputMode, depth, currentDepth + 1, directory);
            }
            catch (UnauthorizedAccessException)
            {
                outputMode.Output($"{new string(' ', (currentDepth + 1) * 5)} No access for {Path.GetFileName(directory)} directory");
            }
        }
    }
}