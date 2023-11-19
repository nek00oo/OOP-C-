using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public abstract class CommandParserBase : ICommandParser
{
    protected IFlagParse? FlagParse { get; private set; }
    protected ICommandParser? NextCommand { get; private set; }

    public ICommandParser SetNextCommandParse(ICommandParser nextCommand)
    {
        NextCommand = nextCommand;
        return nextCommand;
    }

    public ICommandParser SetChainFlagParse(params IFlagParse[] flagParses)
    {
        FlagParse = flagParses[0];
        IFlagParse currentFlag = FlagParse;
        for (int i = 1; i < flagParses.Length; i++)
        {
            currentFlag?.SetNext(flagParses[i]);
            currentFlag = flagParses[i];
        }

        return this;
    }

    public abstract ParseResult CheckCommand(IIterator iterator);
}