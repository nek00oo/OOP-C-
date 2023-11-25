using System;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse.FlagArgument;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

public class FileSystemModeParse : FlagParseBase
{
    public override IFlagArgument CheckValue(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "-M" && iterator.MoveNext())
        {
            if (iterator.GetCurrent().ToUpperInvariant() == "LOCAL")
            {
                return new FileSystemModeValue(new FileSystemMode.Local());
            }

            throw new InvalidOperationException("file system mode is not implemented");
        }

        return new FileSystemModeValue(null);
    }
}