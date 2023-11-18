using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class ShowFile : ICommand
{
    private string? _filename;
    private IOutputMode? _outputMode;

    public void SetParameters(string? filename, IOutputMode? outputMode)
    {
        _filename = filename;
        _outputMode = outputMode;
    }

    public OperationResult Execute(IExecuteContext executeContext)
    {
        if (_filename is not null && _outputMode is not null)
            return executeContext.ShowFile(_outputMode, _filename);
        return new OperationResult.ExecutionError();
    }
}