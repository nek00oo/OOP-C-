using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Tree;

public class ListParse : CommandParserBase
{
    public override ParseResult CheckCommand(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "LIST")
        {
            if (iterator.MoveNext() && FlagParse is not null)
            {
                FlagsArgument flagsArgument = FlagParse.CheckValue(iterator);
                return new ParseResult.Success(new TreeListCommand(flagsArgument?.OutputMode, flagsArgument?.Depth));
            }
        }

        return NextCommand?.CheckCommand(iterator) ?? new ParseResult.CommandNotDetected();
    }
}