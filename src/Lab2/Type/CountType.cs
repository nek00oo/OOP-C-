using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Type;

public class CountType
{
    public CountType(int count)
    {
        if (count < 0)
            throw new InvalidOperationException("Negative number of non-negative types");
        Count = count;
    }

    public int Count { get; set; }
}