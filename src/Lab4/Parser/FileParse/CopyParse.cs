using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileParse;

public class CopyParse : CommandParserBase
{
    public override ParseResult CheckCommand(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "COPY" && iterator.MoveNext())
        {
            string sourcePath = iterator.GetCurrent();
            if (iterator.MoveNext())
                return new ParseResult.Success(new CopyFileCommand(sourcePath, iterator.GetCurrent()));

            return new ParseResult.CommandNotDetected();
        }

        return NextCommand?.CheckCommand(iterator) ?? new ParseResult.CommandNotDetected();
    }
}