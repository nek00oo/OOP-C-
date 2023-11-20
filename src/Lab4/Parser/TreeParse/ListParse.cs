using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.TreeParse;

public class ListParse : CommandParserBase
{
    public override ParseResult CheckCommand(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "LIST")
        {
            IOutputMode? outputMode = null;
            int? depth = null;
            while (iterator.MoveNext())
            {
                foreach (IFlagParse flagParse in FlagParse)
                {
                    FlagsArgument flagsArgument = flagParse.CheckValue(iterator);
                    if (flagsArgument.OutputMode is not null)
                        outputMode = flagsArgument.OutputMode;
                    if (flagsArgument.Depth is not null)
                        depth = flagsArgument.Depth;
                }
            }

            return new ParseResult.Success(new TreeListCommand(outputMode, depth));
        }

        return NextCommand?.CheckCommand(iterator) ?? new ParseResult.CommandNotDetected();
    }
}