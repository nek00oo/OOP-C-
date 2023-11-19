using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Connect;

public class ConnectParse : CommandParserBase
{
    public override ParseResult CheckCommand(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "CONNECT" && iterator.MoveNext())
        {
            string adress = iterator.GetCurrent();
            if (iterator.MoveNext() && FlagParse is not null)
            {
                FlagsArgument flagsArgument = FlagParse.CheckValue(iterator);
                return new ParseResult.Success(new ConnectCommand(adress, flagsArgument?.FileSystemMode));
            }
        }

        return NextCommand?.CheckCommand(iterator) ?? new ParseResult.CommandNotDetected();
    }
}