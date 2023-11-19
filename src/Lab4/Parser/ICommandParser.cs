using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public interface ICommandParser
{
    ICommandParser SetNextCommandParse(ICommandParser nextCommand);
    ICommandParser SetChainFlagParse(params IFlagParse[] flagParses);
    ParseResult CheckCommand(IIterator iterator);
}