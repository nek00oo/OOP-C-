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
                if (iterator.MoveNext())
                    return NextFlag?.CheckValue(iterator).WithMode(new ConsoleOutputMode()) ?? new FlagsArgument();
                return new FlagsArgument().WithMode(new ConsoleOutputMode());
            }

            throw new InvalidOperationException("output mode is not implemented");
        }

        return NextFlag?.CheckValue(iterator) ?? new FlagsArgument();
    }
}