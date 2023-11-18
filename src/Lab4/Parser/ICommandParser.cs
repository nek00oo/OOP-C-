using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public interface ICommandParser
{
    ICommandParser SetNextCommand(ICommandParser nextCommand);
    void SetNextSupportiveCommand(ISupportiveParse nextCommand);
    CommandArgument CheckCommand(IIterator iterator);
}