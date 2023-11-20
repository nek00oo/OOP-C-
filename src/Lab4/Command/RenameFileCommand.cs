using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class RenameFileCommand : ICommand
{
    private readonly string _filePath;
    private readonly string _newFileName;

    public RenameFileCommand(string filePath, string newFileName)
    {
        _filePath = filePath;
        _newFileName = newFileName;
    }

    public OperationResult Execute(IExecuteContext? executeContext)
    {
        return executeContext?.RenameFile(_filePath, _newFileName) ?? new OperationResult.ExecutionError("check the connection to the file system");
    }
}