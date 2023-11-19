using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class TreeListCommand : ICommand
{
    private readonly IOutputMode? _outputMode;
    private readonly int _depth = 1;

    public TreeListCommand(IOutputMode? outputMode, int? depth)
    {
        if (depth > 1)
            _depth = (int)depth;
        _outputMode = outputMode;
    }

    public OperationResult Execute(IExecuteContext? executeContext)
    {
        if (executeContext is not null && _outputMode is not null)
            return executeContext.TreeList(_outputMode, _depth);
        return new OperationResult.ExecutionError();
    }
}