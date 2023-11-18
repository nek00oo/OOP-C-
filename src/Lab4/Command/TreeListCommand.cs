using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class TreeListCommand : ICommand
{
    private IOutputMode? _outputMode;
    private int _depth = 1;

    public void SetParameters(IOutputMode? outputMode, int depth)
    {
        if (_depth > 1)
            _depth = depth;
        _outputMode = outputMode;
    }

    public OperationResult Execute(IExecuteContext executeContext)
    {
        if (_outputMode is not null)
            return executeContext.TreeList(_outputMode, _depth);
        return new OperationResult.ExecutionError();
    }
}