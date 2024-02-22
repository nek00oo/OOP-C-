using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Type;

public class SizeType
{
    public SizeType(int lenght, int width)
    {
        if (lenght < 0 || width < 0)
            throw new InvalidOperationException($"The values of length {lenght} and width {width} cannot be negative");
        Lenght = lenght;
        Width = width;
    }

    public int Lenght { get; }
    public int Width { get; }
}