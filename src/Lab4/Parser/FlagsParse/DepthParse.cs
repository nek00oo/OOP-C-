using System;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse.FlagArgument;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

public class DepthParse : FlagParseBase
{
    public override IFlagArgument CheckValue(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "-D" && iterator.MoveNext())
        {
            if (int.TryParse(iterator.GetCurrent(), out int depth))
            {
                return new DepthValue(depth);
            }

            throw new InvalidOperationException("failed to read the depth");
        }

        return new DepthValue(null);
    }
}