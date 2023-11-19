using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Tree;

public class TreeParse : CommandParserBase
{
    public override ParseResult CheckCommand(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "TREE" && iterator.MoveNext())
        {
            return NextCommand?.CheckCommand(iterator) ?? new ParseResult.CommandNotDetected();
        }

        return new ParseResult.CommandNotDetected();
    }
}