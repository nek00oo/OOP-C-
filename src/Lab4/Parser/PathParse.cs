using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class PathParse : CommandParserBase
{
    public override CommandArgument CheckCommand(IIterator iterator)
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