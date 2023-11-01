using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Messenger;

public class Messenger : IMessenger
{
    public void WriteText(string text)
    {
        if (text == null)
            throw new InvalidOperationException("No output text found");
        Console.WriteLine("Messenger :" + text);
    }
}