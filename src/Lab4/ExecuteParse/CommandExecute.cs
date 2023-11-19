using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;

namespace Itmo.ObjectOrientedProgramming.Lab4.ExecuteParse;

public class CommandExecute
{
    private readonly ICommandParser _command;
    private IExecuteContext? _executeContext;

    public CommandExecute(ICommandParser commandParser)
    {
        _command = commandParser;
    }

    public ExecuteResult ExecuteParse(string command)
    {
        IIterator iterator = new CommandIterator(command);
        if (_command.CheckCommand(iterator) is ParseResult.Success success)
        {
            if (success.Command.Execute(_executeContext) is OperationResult.Success complete)
            {
                _executeContext = complete.ExecuteContext;
                return new ExecuteResult.Success($"The {success.Command.GetType().Name} is executed");
            }

            return new ExecuteResult.ExecutionError($"The {success.Command.GetType().Name} is not executed");
        }

        return new ExecuteResult.ExecutionError("Command not detected");
    }
}