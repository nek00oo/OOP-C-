using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class CommandParser
{
    private ICommandParser _commandList;

    public CommandParser(ICommandParser commandParser)
    {
        _commandList = commandParser;
    }

    public void Parse(string command)
    {
        IIterator iterator = new CommandIterator(command);
        _commandList.CheckCommand(iterator);
    }
}