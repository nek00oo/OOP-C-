using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public abstract class CommandParserBase : ICommandParser
{
    protected CommandParserBase()
    {
        IntoCommand = new List<ISupportiveParse>();
    }

    protected IList<ISupportiveParse> IntoCommand { get; }
    protected ICommandParser? NextCommand { get; private set; }

    public ICommandParser SetNextCommand(ICommandParser nextCommand)
    {
        NextCommand = nextCommand;
        return this;
    }

    public void SetNextSupportiveCommand(ISupportiveParse nextCommand)
    {
        IntoCommand.Add(nextCommand);
    }

    public abstract CommandArgument CheckCommand(IIterator iterator);
}