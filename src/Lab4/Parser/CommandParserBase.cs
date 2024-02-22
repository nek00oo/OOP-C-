using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public abstract class CommandParserBase : ICommandParser
{
    protected CommandParserBase()
    {
        FlagParse = new List<IFlagParse>();
    }

    protected IList<IFlagParse> FlagParse { get; private set; }
    protected ICommandParser? NextCommand { get; private set; }

    public ICommandParser SetNextCommandParse(ICommandParser nextCommand)
    {
        NextCommand = nextCommand;
        return nextCommand;
    }

    public ICommandParser SetChainFlagParse(params IFlagParse[] flagParses)
    {
        FlagParse = flagParses;
        return this;
    }

    public abstract ParseResult CheckCommand(IIterator iterator);
}