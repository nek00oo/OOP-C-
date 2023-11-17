using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public abstract class CommandParserBase : ICommandParser
{
    protected ICommandParser? NextCommand { get; private set; }
    protected ICommandParser? IntoCommand { get; private set; }

    public ICommandParser SetNext(ICommandParser nextCommand, ICommandParser intoCommand)
    {
        NextCommand = nextCommand;
        IntoCommand = intoCommand;
        return this;
    }

    public abstract CommandArgument CheckCommand(IIterator iterator);
}