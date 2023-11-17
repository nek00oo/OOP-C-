using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class ShowFile : ICommand
{
    private readonly string _filename;
    private readonly IOutputMode _outputMode;

    public ShowFile(string filename, IOutputMode outputMode)
    {
        _filename = filename;
        _outputMode = outputMode;
    }

    public OperationResult Execute(IExecuteContext executeContext)
    {
        return executeContext.ShowFile(_outputMode, _filename);
    }
}