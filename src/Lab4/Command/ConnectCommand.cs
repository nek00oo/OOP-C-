using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class ConnectCommand : ICommand
{
    private string? _rootPath;
    private FileSystemMode? _fileSystemMode;

    public void SetParameters(string? rootPath, FileSystemMode? fileSystemMode)
    {
        _rootPath = rootPath;
        _fileSystemMode = fileSystemMode;
    }

    public OperationResult Execute(IExecuteContext executeContext)
    {
        if (_rootPath is not null && _fileSystemMode is not null)
            return executeContext.Connect(_rootPath, _fileSystemMode);
        return new OperationResult.ExecutionError();
    }
}