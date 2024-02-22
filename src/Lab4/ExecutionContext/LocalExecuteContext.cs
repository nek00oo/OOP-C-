using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.IconVisitor;
using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.ValidateCommand;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

public class LocalExecuteContext : IExecuteContext
{
    private string? _rootPath;
    private string? _currentPath;

    public LocalExecuteContext(string rootPath)
    {
        RootPathValidate = new PathIsRooted();
        if (RootPathValidate.Execute(rootPath) is ValidatePathResult.NotExist notExist)
            throw new InvalidOperationException(notExist.Error);
        _rootPath = rootPath;
        _currentPath = rootPath;
        FileExistValidate = new FileIsExistPath();
        DirectoryExistValidate = new DirectoryIsExistPath();
        PathExistValidate = new PathIsExistPath();
    }

    public IValidatePath FileExistValidate { get; }
    public IValidatePath DirectoryExistValidate { get; }
    public IValidatePath PathExistValidate { get; }
    public IValidatePath RootPathValidate { get; }

    public OperationResult Disconnect()
    {
        _rootPath = null;
        _currentPath = null;
        return new OperationResult.Success(this);
    }

    public OperationResult TreeGoTo(string path)
    {
        _currentPath = path;
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
        string content = File.ReadAllText(filename);
        outputMode.Output(content);
        return new OperationResult.Success(this);
    }

    public OperationResult MoveFile(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, Path.Combine(destinationPath, Path.GetFileName(sourcePath)));
        return new OperationResult.Success(this);
    }

    public OperationResult CopyFile(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, Path.Combine(destinationPath, Path.GetFileName(sourcePath)));
        return new OperationResult.Success(this);
    }

    public OperationResult FileDelete(string fileName)
    {
        File.Delete(fileName);
        return new OperationResult.Success(this);
    }

    public OperationResult RenameFile(string filePath, string newFileName)
    {
        string? directoryFullPath = Path.GetDirectoryName(filePath);
        if (directoryFullPath != null)
        {
            string newFilePath = Path.Combine(directoryFullPath, newFileName);
            File.Move(filePath, newFilePath);
            return new OperationResult.Success(this);
        }

        File.Move(filePath, newFileName);

        return new OperationResult.Success(this);
    }

    public string GetFullPath(string path)
    {
        if (RootPathValidate.Execute(path) is ValidatePathResult.Success)
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
            if (DirectoryExistValidate.Execute(directory) is ValidatePathResult.Success) icon = iconsVisitor.VisitFolderIcon();
            else if (FileExistValidate.Execute(directory) is ValidatePathResult.Success) icon = iconsVisitor.VisitFileIcon();
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