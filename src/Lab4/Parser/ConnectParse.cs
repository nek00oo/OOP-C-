using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class ConnectParse : CommandParserBase
{
    public override ParseResult CheckCommand(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "CONNECT" && iterator.MoveNext())
        {
            string address = iterator.GetCurrent();
            FileSystemMode? fileSystemMode = null;
            while (iterator.MoveNext())
            {
                foreach (IFlagParse flagParse in FlagParse)
                {
                    FlagsArgument flagsArgument = flagParse.CheckValue(iterator);
                    if (flagsArgument.FileSystemMode is not null)
                        fileSystemMode = flagsArgument.FileSystemMode;
                }

                return new ParseResult.Success(new ConnectCommand(address, fileSystemMode));
            }
        }

        return NextCommand?.CheckCommand(iterator) ?? new ParseResult.CommandNotDetected();
    }
}