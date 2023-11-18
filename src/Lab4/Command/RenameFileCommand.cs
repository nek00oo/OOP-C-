using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class RenameFileCommand : ICommand
{
    private string? _filePath;
    private string? _newFileName;

    public void SetParameters(string? filePath, string? newFileName)
    {
        _filePath = filePath;
        _newFileName = newFileName;
    }

    public OperationResult Execute(IExecuteContext executeContext)
    {
        if (_filePath is not null && _newFileName is not null)
            return executeContext.RenameFile(_filePath, _newFileName);
        return new OperationResult.ExecutionError();
    }
}