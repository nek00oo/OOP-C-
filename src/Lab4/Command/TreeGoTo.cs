using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class TreeGoTo : ICommand
{
    private string? _path;

    public void SetParameters(string path)
    {
        _path = path;
    }

    public OperationResult Execute(IExecuteContext executeContext)
    {
        if (_path is not null)
            return executeContext.TreeGoTo(_path);
        return new OperationResult.ExecutionError();
    }
}