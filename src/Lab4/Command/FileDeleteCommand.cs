using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class FileDeleteCommand : ICommand
{
    private readonly string _fileName;

    public FileDeleteCommand(string fileName)
    {
        _fileName = fileName;
    }

    public OperationResult Execute(IExecuteContext? executeContext)
    {
        return executeContext?.FileDelete(_fileName) ?? new OperationResult.ExecutionError("check the connection to the file system");
    }
}