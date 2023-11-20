using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

public interface IFlagParse
{
    FlagsArgument CheckValue(IIterator iterator);
}