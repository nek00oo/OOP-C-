using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Tree;

public class GoToParse : SupportiveParseBase
{
    public override CommandArgument CheckCommand(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "GOTO")
        {
            if (iterator.MoveNext())
            {
                return new CommandArgument.Success(new TreeGoTo().SetParameters(iterator.GetCurrent()));
            }
        }

        return new CommandArgument.CommandNotDetected();
    }
}