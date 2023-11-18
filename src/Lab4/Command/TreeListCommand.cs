using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class TreeListCommand : ICommand
{
    private IOutputMode? _outputMode;
    private int _depth = 1;

    public TreeListCommand SetParameters(IOutputMode? outputMode, int? depth)
    {
        if (depth != null && depth > 1)
            _depth = (int)depth;
        _outputMode = outputMode;
        return this;
    }

    public OperationResult Execute(IExecuteContext executeContext)
    {
        if (_outputMode is not null)
            return executeContext.TreeList(_outputMode, _depth);
        return new OperationResult.ExecutionError();
    }
}