using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class PathParse : CommandParserBase
{
    public override CommandArgument CheckCommand(IIterator iterator, ICommand? command)
    {
        if (NextCommand is null)
            return new CommandArgument.Success(iterator.GetCurrent());
        if (iterator.MoveNext())
        {
            return NextCommand.CheckCommand(iterator);
        }

        return new CommandArgument.CommandNotDetected();
    }
}