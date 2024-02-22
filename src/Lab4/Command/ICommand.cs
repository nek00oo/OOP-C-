using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public interface ICommand
{
    OperationResult Execute(IExecuteContext? executeContext);
}