using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Tree;

public class TreeParse : CommandParserBase
{
    public override CommandArgument CheckCommand(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "TREE")
        {
            if (iterator.MoveNext())
            {
                return IntoCommand?.CheckCommand(iterator) ?? new CommandArgument.CommandNotDetected();
            }
        }

        return NextCommand?.CheckCommand(iterator) ?? new CommandArgument.CommandNotDetected();
    }
}