using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;
using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.ValidateCommand;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class ShowFile : ICommand
{
    private readonly string _filename;
    private readonly IOutputMode _outputMode;

    public ShowFile(string filename, IOutputMode? outputMode)
    {
        _filename = filename;
        _outputMode = new ConsoleOutputMode();
        if (outputMode is not null)
            _outputMode = outputMode;
    }

    public OperationResult Execute(IExecuteContext? executeContext)
    {
        if (executeContext is null)
            return new OperationResult.ExecutionError("check the connection to the file system");
        string fullFileName = executeContext.GetFullPath(_filename);
        if (executeContext.FileExistValidate.Execute(fullFileName) is ValidatePathResult.NotExist notExist)
            return new OperationResult.ExecutionError(notExist.Error);
        return executeContext.ShowFile(_outputMode, fullFileName);
    }
}