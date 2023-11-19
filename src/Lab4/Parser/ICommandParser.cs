using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public interface ICommandParser
{
    ICommandParser SetNextCommand(ICommandParser nextCommand);
    void SetNextSupportiveCommand(IFlagParse flagParse);
    ParseResult CheckCommand(IIterator iterator);
}