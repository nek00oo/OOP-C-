using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class TreeListCommand : ICommand
{
    private readonly IOutputMode _outputMode;
    private readonly int _depth;

    public TreeListCommand(IOutputMode outputMode, int depth)
    {
        _outputMode = outputMode;
        _depth = depth;
    }

    public OperationResult Execute(IExecuteContext executeContext)
    {
        return executeContext.TreeList(_outputMode, _depth);
    }
}