using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

public abstract class FlagParseBase : IFlagParse
{
    protected IFlagParse? NextFlag { get; set; }
    public IFlagParse SetNext(IFlagParse flagParse)
    {
        NextFlag = flagParse;
        return flagParse;
    }

    public abstract FlagsArgument CheckValue(IIterator iterator);
}