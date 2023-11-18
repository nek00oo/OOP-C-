using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Connect;

public class ConnectParse : CommandParserBase
{
    public override CommandArgument CheckCommand(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "CONNECT" && iterator.MoveNext())
        {
            foreach (ISupportiveParse commandParse in IntoCommand)
            {
                if (commandParse.CheckCommand(iterator) is CommandArgument.Success success)
                    return success;
            }
        }

        return NextCommand?.CheckCommand(iterator) ?? new CommandArgument.CommandNotDetected();
    }
}