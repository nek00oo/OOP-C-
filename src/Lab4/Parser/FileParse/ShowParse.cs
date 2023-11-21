using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileParse;

public class ShowParse : CommandParserBase
{
    public override ParseResult CheckCommand(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "SHOW" && iterator.MoveNext())
        {
            string fileName = iterator.GetCurrent();
            if (iterator.MoveNext())
            {
                foreach (IFlagParse flagParse in FlagParse)
                {
                    FlagsArgument flagsArgument = flagParse.CheckValue(iterator);
                    if (flagsArgument.OutputMode is not null)
                        return new ParseResult.Success(new ShowFile(fileName, flagsArgument.OutputMode));
                }
            }
        }

        return NextCommand?.CheckCommand(iterator) ?? new ParseResult.CommandNotDetected();
    }
}