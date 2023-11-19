using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class FileDeleteCommand : ICommand
{
    private readonly string? _fileName;

    public FileDeleteCommand(string? fileName)
    {
        _fileName = fileName;
    }

    public OperationResult Execute(IExecuteContext? executeContext)
    {
        if (_fileName is not null)
            return executeContext?.FileDelete(_fileName) ?? new OperationResult.ExecutionError();
        return new OperationResult.ExecutionError();
    }
}