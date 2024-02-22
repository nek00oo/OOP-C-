using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;
using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.ValidateCommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class TreeGoTo : ICommand
{
    private readonly string _path;

    public TreeGoTo(string path)
    {
        _path = path;
    }

    public OperationResult Execute(IExecuteContext? executeContext)
    {
        if (executeContext is null)
            return new OperationResult.ExecutionError("check the connection to the file system");

        string fullPath = executeContext.GetFullPath(_path);
        if (executeContext.PathExistValidate.Execute(fullPath) is ValidatePathResult.NotExist notExist)
            return new OperationResult.ExecutionError(notExist.Error);

        return executeContext.TreeGoTo(fullPath);
    }
}