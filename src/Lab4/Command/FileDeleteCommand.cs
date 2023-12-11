using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;
using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.ValidateCommand;

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
        if (executeContext is null)
            return new OperationResult.ExecutionError("check the connection to the file system");

        string fullFileName = executeContext.GetFullPath(_fileName);
        if (executeContext.FileExistValidate.Execute(fullFileName) is ValidatePathResult.NotExist notExistFile)
            return new OperationResult.ExecutionError(notExistFile.Error);
        return executeContext.FileDelete(fullFileName);
    }
}