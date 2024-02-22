using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Display;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void ShowText(string text)
    {
        _displayDriver.ClearOutput();
        _displayDriver.OutputText(text);
    }

    public void SetColor(Color color)
    {
        _displayDriver.SetColor(color);
    }
}