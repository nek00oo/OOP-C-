using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse.FlagArgument;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

public abstract class FlagParseBase : IFlagParse
{
    public abstract IFlagArgument CheckValue(IIterator iterator);
}