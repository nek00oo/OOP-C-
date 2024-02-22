using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse.FlagArgument;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class ConnectParse : CommandParserBase
{
    public override ParseResult CheckCommand(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "CONNECT" && iterator.MoveNext())
        {
            string address = iterator.GetCurrent();
            FileSystemMode? fileSystemMode = null;
            if (iterator.MoveNext())
            {
                foreach (IFlagParse flagParse in FlagParse)
                {
                    IFlagArgument flagsArgument = flagParse.CheckValue(iterator);
                    if (flagsArgument is FileSystemModeValue { SystemMode: not null } value)
                        fileSystemMode = value.SystemMode;
                }

                return new ParseResult.Success(new ConnectCommand(address, fileSystemMode));
            }
        }

        return NextCommand?.CheckCommand(iterator) ?? new ParseResult.CommandNotDetected();
    }
}