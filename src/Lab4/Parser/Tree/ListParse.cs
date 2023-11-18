using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Tree;

public class ListParse : SupportiveParseBase
{
    public override CommandArgument CheckCommand(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "LIST")
        {
            if (iterator.MoveNext() && FlagParse is not null)
            {
                FlagsArgument flagsArgument = FlagParse.CheckValue(iterator);
                return new CommandArgument.Success(new TreeListCommand().SetParameters(flagsArgument.OutputMode, flagsArgument.Depth));
            }
        }

        return new CommandArgument.CommandNotDetected();
    }
}