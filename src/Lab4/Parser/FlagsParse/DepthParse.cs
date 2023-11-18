using System;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

public class DepthParse : FlagParseBase
{
    public override FlagsArgument CheckValue(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "-D" && iterator.MoveNext())
        {
            if (int.TryParse(iterator.GetCurrent(), out int depth))
            {
                if (iterator.MoveNext())
                    return NextFlag?.CheckValue(iterator).WithDepth(depth) ?? new FlagsArgument();
                return new FlagsArgument(depth);
            }

            throw new InvalidOperationException();
        }

        return NextFlag?.CheckValue(iterator) ?? new FlagsArgument();
    }
}