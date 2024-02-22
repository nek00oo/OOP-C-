using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public class DisconnectCommand : ICommand
{
    public OperationResult Execute(IExecuteContext? executeContext)
    {
        return executeContext?.Disconnect() ?? new OperationResult.ExecutionError("check the connection to the file system");
    }
}