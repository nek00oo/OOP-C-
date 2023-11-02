using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Messenger;

public class Messenger : IMessenger
{
    private string? _text;
    public void WriteText()
    {
        if (_text == null)
            throw new InvalidOperationException("No output text found");
        Console.WriteLine("Messenger:\n" + _text);
    }

    public void ReceiveText(string text) => _text = text;
}