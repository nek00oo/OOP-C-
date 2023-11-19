using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class MoveFileCommand : ICommand
{
    private readonly string? _sourcePath;
    private readonly string? _destinationPath;

    public MoveFileCommand(string? sourcePath, string? destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public OperationResult Execute(IExecuteContext? executeContext)
    {
        if (executeContext is not null && _sourcePath is not null && _destinationPath is not null)
            return executeContext.MoveFile(_sourcePath, _destinationPath);
        return new OperationResult.ExecutionError();
    }
}