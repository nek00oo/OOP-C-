using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Messenger;

public class Messenger : IMessenger
{
    public void WriteText(string text)
    {
        Console.WriteLine("Messenger:\n" + text);
    }
}