using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Tree;

public class ListParse : CommandParserBase
{
    public override CommandArgument CheckCommand(IIterator iterator, ICommand? command)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "LIST")
        {
            if (iterator.MoveNext())
            {
                return IntoCommand?.CheckCommand(iterator, new TreeListCommand()) ?? new CommandArgument.CommandNotDetected();
            }
        }

        return NextCommand?.CheckCommand(iterator) ?? new CommandArgument.CommandNotDetected();
    }
}