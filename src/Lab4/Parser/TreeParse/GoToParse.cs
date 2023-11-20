using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.TreeParse;

public class GoToParse : CommandParserBase
{
    public override ParseResult CheckCommand(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "GOTO")
        {
            if (iterator.MoveNext())
                return new ParseResult.Success(new TreeGoTo(iterator.GetCurrent()));

            return new ParseResult.CommandNotDetected();
        }

        return NextCommand?.CheckCommand(iterator) ?? new ParseResult.CommandNotDetected();
    }
}