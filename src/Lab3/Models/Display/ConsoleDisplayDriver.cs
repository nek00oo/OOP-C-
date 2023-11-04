using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Display;

public class ConsoleDisplayDriver : IDisplayDriver
{
    private Color _color = Color.White;
    public void ClearOutput() => Console.Clear();

    public void SetColor(Color color) => _color = color;

    public void OutputText(string text)
    {
        Console.WriteLine(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(text));
    }
}