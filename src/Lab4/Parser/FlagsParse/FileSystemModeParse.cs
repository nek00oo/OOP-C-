using System;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

public class FileSystemModeParse : FlagParseBase
{
    public override FlagsArgument CheckValue(IIterator iterator)
    {
        if (iterator.GetCurrent().ToUpperInvariant() == "-M" && iterator.MoveNext())
        {
            if (iterator.GetCurrent().ToUpperInvariant() == "LOCAL")
            {
                return new FlagsArgument().WithFileSystemMode(new FileSystemMode.Local());
            }

            throw new InvalidOperationException("file system mode is not implemented");
        }

        return new FlagsArgument();
    }
}