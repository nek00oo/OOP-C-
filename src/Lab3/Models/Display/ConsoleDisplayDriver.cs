using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Display;

public class ConsoleDisplayDriver : IDisplayDriver
{
    private Color _color = Color.Azure;
    private string? _text;
    public void ClearOutput() => Console.Clear();

    public void SetColor(Color color) => _color = color;
    public void ReceiveText(string text) => _text = text;

    public void OutputText()
    {
        if (_text == null)
            throw new InvalidOperationException();
        Console.WriteLine(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(_text));
    }
}