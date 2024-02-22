using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;

public class Logger : ILogger
{
    public void ShowStatus(string log)
    {
        Console.WriteLine(log);
    }
}