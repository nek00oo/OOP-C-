using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class MoveFileCommand : ICommand
{
    private string? _sourcePath;
    private string? _destinationPath;

    public void SetParameters(string? sourcePath, string? destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public OperationResult Execute(IExecuteContext executeContext)
    {
        if (_sourcePath is not null && _destinationPath is not null)
            return executeContext.MoveFile(_sourcePath, _destinationPath);
        return new OperationResult.ExecutionError();
    }
}