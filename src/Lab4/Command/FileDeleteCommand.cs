using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class FileDeleteCommand : ICommand
{
    private string? _fileName;

    public void SetParameters(string? fileName)
    {
        _fileName = fileName;
    }

    public OperationResult Execute(IExecuteContext executeContext)
    {
        if (_fileName is not null)
            return executeContext.FileDelete(_fileName);
        return new OperationResult.ExecutionError();
    }
}