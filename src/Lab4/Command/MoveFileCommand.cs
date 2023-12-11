using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;
using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.ValidateCommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class MoveFileCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public MoveFileCommand(string sourcePath, string destinationPath)
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

        if (executeContext.FileExistValidate.Execute(fullSourcePath) is ValidatePathResult.NotExist notExist)
            return new OperationResult.ExecutionError(notExist.Error);
        if (executeContext.DirectoryExistValidate.Execute(fullDestinationPath) is ValidatePathResult.NotExist notExistDirectory)
            return new OperationResult.ExecutionError(notExistDirectory.Error);

        return executeContext.MoveFile(fullSourcePath, fullDestinationPath);
    }
}