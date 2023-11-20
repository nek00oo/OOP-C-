using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileParse;

public class DeleteParse : CommandParserBase
{
    public override ParseResult CheckCommand(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "DELETE")
        {
            if (iterator.MoveNext())
                return new ParseResult.Success(new FileDeleteCommand(iterator.GetCurrent()));

            return new ParseResult.CommandNotDetected();
        }

        return NextCommand?.CheckCommand(iterator) ?? new ParseResult.CommandNotDetected();
    }
}