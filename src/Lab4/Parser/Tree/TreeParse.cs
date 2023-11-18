using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Tree;

public class TreeParse : CommandParserBase
{
    public TreeParse()
    {
        SetNextSupportiveCommand(new ListParse());
        SetNextSupportiveCommand(new GoToParse());
    }

    public override CommandArgument CheckCommand(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "TREE" && iterator.MoveNext())
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