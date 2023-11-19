using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class RenameFileCommand : ICommand
{
    private readonly string? _filePath;
    private readonly string? _newFileName;

    public RenameFileCommand(string? filePath, string? newFileName)
    {
        _filePath = filePath;
        _newFileName = newFileName;
    }

    public OperationResult Execute(IExecuteContext? executeContext)
    {
        if (executeContext is not null && _filePath is not null && _newFileName is not null)
            return executeContext.RenameFile(_filePath, _newFileName);
        return new OperationResult.ExecutionError();
    }
}