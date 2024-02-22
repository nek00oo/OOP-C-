using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse.FlagArgument;

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
                    IFlagArgument flagsArgument = flagParse.CheckValue(iterator);
                    if (flagsArgument is OutputModeValue { Mode: not null } modeValue)
                        outputMode = modeValue.Mode;
                    if (flagsArgument is DepthValue { Depth: not null } value)
                        depth = value.Depth;
                }
            }

            return new ParseResult.Success(new TreeListCommand(outputMode, depth));
        }

        return NextCommand?.CheckCommand(iterator) ?? new ParseResult.CommandNotDetected();
    }
}