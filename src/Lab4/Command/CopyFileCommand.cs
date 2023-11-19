using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class CopyFileCommand : ICommand
{
    private readonly string? _sourcePath;
    private readonly string? _destinationPath;

    public CopyFileCommand(string? sourcePath, string? destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public OperationResult Execute(IExecuteContext? executeContext)
    {
        if (_sourcePath is not null && _destinationPath is not null)
            return executeContext?.CopyFile(_sourcePath, _destinationPath) ?? new OperationResult.ExecutionError();
        return new OperationResult.ExecutionError();
    }
}