using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public interface ICommandParser
{
    ICommandParser SetNext(ICommandParser nextCommand, ICommandParser intoCommand);
    CommandArgument CheckCommand(IIterator iterator);
}