using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public interface ISupportiveParse
{
    void SetSupportiveCommand(IFlagParse flagParse);
    CommandArgument CheckCommand(IIterator iterator);
}