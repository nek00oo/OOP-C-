using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class ConnectCommand : ICommand
{
    private readonly string _rootPath;
    private readonly FileSystemMode? _fileSystemMode;

    public ConnectCommand(string rootPath, FileSystemMode? fileSystemMode)
    {
        _rootPath = rootPath;
        _fileSystemMode = fileSystemMode;
    }

    public OperationResult Execute(IExecuteContext? executeContext)
    {
        if (_fileSystemMode is FileSystemMode.Local)
            return new OperationResult.Success(new LocalExecuteContext(_rootPath));
        return new OperationResult.ExecutionError("Work with the specified file system has not yet been implemented");
    }
}