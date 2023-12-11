using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;
using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.ValidateCommand;

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
        if (executeContext is null)
            return new OperationResult.ExecutionError("check the connection to the file system");
        string fullFilePath = executeContext.GetFullPath(_filePath);
        if (executeContext.FileExistValidate.Execute(fullFilePath) is ValidatePathResult.NotExist notExistFile)
            return new OperationResult.ExecutionError(notExistFile.Error);
        return executeContext.RenameFile(_filePath, fullFilePath);
    }
}