using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class TreeGoTo : ICommand
{
    private readonly string? _path;

    public TreeGoTo(string? path)
    {
        _path = path;
    }

    public OperationResult Execute(IExecuteContext? executeContext)
    {
        if (executeContext is not null && _path is not null)
            return executeContext.TreeGoTo(_path);
        return new OperationResult.ExecutionError();
    }
}