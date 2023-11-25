using System;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse.FlagArgument;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

public class OutputModeParse : FlagParseBase
{
    public override IFlagArgument CheckValue(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "-M" && iterator.MoveNext())
        {
            if (iterator.GetCurrent().ToUpperInvariant() == "CONSOLE")
            {
                return new OutputModeValue(new ConsoleOutputMode());
            }

            throw new InvalidOperationException("output mode is not implemented");
        }

        return new OutputModeValue(null);
    }
}