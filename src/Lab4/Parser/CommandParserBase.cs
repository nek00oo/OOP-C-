using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public abstract class CommandParserBase : ICommandParser
{
    protected IFlagParse? FlagParse { get; set; }
    protected ICommandParser? NextCommand { get; private set; }

    public ICommandParser SetNextCommand(ICommandParser nextCommand)
    {
        NextCommand = nextCommand;
        return this;
    }

    public void SetNextSupportiveCommand(IFlagParse flagParse)
    {
        FlagParse = flagParse;
    }

    public abstract ParseResult CheckCommand(IIterator iterator);
}