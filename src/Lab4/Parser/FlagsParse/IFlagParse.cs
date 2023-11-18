using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

public interface IFlagParse
{
    IFlagParse SetNext(IFlagParse flagParse);
    FlagsArgument CheckValue(IIterator iterator);
}