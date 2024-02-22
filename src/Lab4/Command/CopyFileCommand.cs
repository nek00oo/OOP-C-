using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;
using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.ValidateCommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class CopyFileCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public CopyFileCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public OperationResult Execute(IExecuteContext? executeContext)
    {
        if (executeContext is null)
            return new OperationResult.ExecutionError("check the connection to the file system");

        string fullSourcePath = executeContext.GetFullPath(_sourcePath);
        string fullDestinationPath = executeContext.GetFullPath(_destinationPath);

        if (executeContext.FileExistValidate.Execute(fullSourcePath) is ValidatePathResult.NotExist notExistFile)
            return new OperationResult.ExecutionError(notExistFile.Error);
        if (executeContext.DirectoryExistValidate.Execute(fullDestinationPath) is ValidatePathResult.NotExist notExistDirectory)
            return new OperationResult.ExecutionError(notExistDirectory.Error);

        return executeContext.CopyFile(fullSourcePath, fullDestinationPath);
    }
}