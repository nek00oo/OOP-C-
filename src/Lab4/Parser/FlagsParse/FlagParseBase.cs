using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

public abstract class FlagParseBase : IFlagParse
{
    public abstract FlagsArgument CheckValue(IIterator iterator);
}