using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

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
        return executeContext?.MoveFile(_sourcePath, _destinationPath) ?? new OperationResult.ExecutionError("check the connection to the file system");
    }
}