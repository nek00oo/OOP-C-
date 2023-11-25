using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.IconVisitor;
using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.ValidateCommand;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

public class LocalExecuteContext : IExecuteContext
{
    private readonly IValidatePath _fileExistValidate;
    private readonly IValidatePath _directoryExistValidate;
    private readonly IValidatePath _pathExistValidate;
    private readonly IValidatePath _rootPathValidate;
    private string? _rootPath;
    private string? _currentPath;

    public LocalExecuteContext(string rootPath)
    {
        _rootPathValidate = new PathIsRooted();
        if (_rootPathValidate.Execute(rootPath) is ValidatePathResult.NotExist notExist)
            throw new InvalidOperationException(notExist.Error);
        _rootPath = rootPath;
        _currentPath = rootPath;
        _fileExistValidate = new FileIsExistPath();
        _directoryExistValidate = new DirectoryIsExistPath();
        _pathExistValidate = new PathIsExistPath();
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
        if (_pathExistValidate.Execute(fullPath) is ValidatePathResult.NotExist notExist)
            return new OperationResult.ExecutionError(notExist.Error);

        _currentPath = fullPath;
        return new OperationResult.Success(this);
    }

    public OperationResult TreeList(IOutputMode outputMode, IIconsVisitor? iconsVisitor, int depth)
    {
        if (_currentPath is null)
            return new OperationResult.ExecutionError("the specified directory does not exist");
        iconsVisitor ??= new JsonIconVisitor("C:\\Users\\valer\\RiderProjects\\nek00oo\\src\\Lab4\\Icons.json");
        TreeList(outputMode, depth, 0, _currentPath, iconsVisitor);

        return new OperationResult.Success(this);
    }

    public OperationResult ShowFile(IOutputMode outputMode, string filename)
    {
        string fullPathFileName = GetFullPath(filename);

        if (_fileExistValidate.Execute(fullPathFileName) is ValidatePathResult.NotExist notExist)
            return new OperationResult.ExecutionError(notExist.Error);

        string content = File.ReadAllText(filename);
        outputMode.Output(content);
        return new OperationResult.Success(this);
    }

    public OperationResult MoveFile(string sourcePath, string destinationPath)
    {
        string sourceFullPath = GetFullPath(sourcePath);
        string destinationFullPath = GetFullPath(destinationPath);
        if (_fileExistValidate.Execute(sourceFullPath) is ValidatePathResult.NotExist notExistFile)
            return new OperationResult.ExecutionError(notExistFile.Error);
        if (_directoryExistValidate.Execute(destinationFullPath) is ValidatePathResult.NotExist notExistDirectory)
            return new OperationResult.ExecutionError(notExistDirectory.Error);

        File.Move(sourceFullPath, Path.Combine(destinationFullPath, Path.GetFileName(sourceFullPath)));
        return new OperationResult.Success(this);
    }

    public OperationResult CopyFile(string sourcePath, string destinationPath)
    {
        string sourceFullPath = GetFullPath(sourcePath);
        string destinationFullPath = GetFullPath(destinationPath);
        if (_fileExistValidate.Execute(sourceFullPath) is ValidatePathResult.NotExist notExistFile)
            return new OperationResult.ExecutionError(notExistFile.Error);
        if (_directoryExistValidate.Execute(destinationFullPath) is ValidatePathResult.NotExist notExistDirectory)
            return new OperationResult.ExecutionError(notExistDirectory.Error);

        File.Copy(sourceFullPath, Path.Combine(destinationFullPath, Path.GetFileName(sourceFullPath)));
        return new OperationResult.Success(this);
    }

    public OperationResult FileDelete(string fileName)
    {
        string fullPath = GetFullPath(fileName);

        if (_fileExistValidate.Execute(fullPath) is ValidatePathResult.NotExist notExistFile)
            return new OperationResult.ExecutionError(notExistFile.Error);

        File.Delete(fullPath);
        return new OperationResult.Success(this);
    }

    public OperationResult RenameFile(string filePath, string newFileName)
    {
        string fullPath = GetFullPath(filePath);

        if (_fileExistValidate.Execute(fullPath) is ValidatePathResult.NotExist notExistFile)
            return new OperationResult.ExecutionError(notExistFile.Error);

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
        if (_rootPathValidate.Execute(path) is ValidatePathResult.Success)
            return path;
        return _rootPath == null ? string.Empty : Path.Combine(_rootPath, path);
    }

    private void TreeList(IOutputMode outputMode, int depth, int currentDepth, string path, IIconsVisitor iconsVisitor)
    {
        if (currentDepth >= depth)
            return;
        if (Directory.Exists(path) is false) return;

        string[] directories = Directory.GetFileSystemEntries(path);
        outputMode.Output($"{new string(' ', currentDepth * 5)}|");
        foreach (string directory in directories)
        {
            string? icon;
            if (_directoryExistValidate.Execute(directory) is ValidatePathResult.Success) icon = iconsVisitor.VisitFolderIcon();
            else if (_fileExistValidate.Execute(directory) is ValidatePathResult.Success) icon = iconsVisitor.VisitFileIcon();
            else icon = "??";
            try
            {
                outputMode.Output($"{new string(' ', currentDepth * 5)}|_{icon}[{Path.GetFileName(directory)}]");
                TreeList(outputMode, depth, currentDepth + 1, directory, iconsVisitor);
            }
            catch (UnauthorizedAccessException)
            {
                outputMode.Output($"{new string(' ', (currentDepth + 1) * 5)}{iconsVisitor.VisitNoAccessIcon()}  No access for {Path.GetFileName(directory)} directory");
            }
        }
    }
}