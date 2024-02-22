using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

public class ConsoleOutputMode : IOutputMode
{
    public void Output(string name)
    {
        Console.WriteLine(name);
    }
}