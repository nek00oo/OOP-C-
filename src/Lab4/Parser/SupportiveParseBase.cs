using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public abstract class SupportiveParseBase : ISupportiveParse
{
    protected IFlagParse? FlagParse { get; set; }

    public void SetSupportiveCommand(IFlagParse flagParse)
    {
        FlagParse = flagParse;
    }

    public abstract CommandArgument CheckCommand(IIterator iterator);
}