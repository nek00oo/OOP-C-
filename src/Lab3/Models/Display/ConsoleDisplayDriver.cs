using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Display;

public class ConsoleDisplayDriver : IDisplayDriver
{
    private Color _color = Color.Azure;
    public void ClearOutput() => Console.Clear();

    public void SetColor(Color color) => _color = color;

    public void OutputText(string text)
    {
        Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(text);
    }
}