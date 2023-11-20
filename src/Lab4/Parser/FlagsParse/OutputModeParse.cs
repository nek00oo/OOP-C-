using System;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

public class OutputModeParse : FlagParseBase
{
    public override FlagsArgument CheckValue(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "-M" && iterator.MoveNext())
        {
            if (iterator.GetCurrent().ToUpperInvariant() == "CONSOLE")
            {
                return new FlagsArgument().WithOutputMode(new ConsoleOutputMode());
            }

            throw new InvalidOperationException("output mode is not implemented");
        }

        return new FlagsArgument();
    }
}