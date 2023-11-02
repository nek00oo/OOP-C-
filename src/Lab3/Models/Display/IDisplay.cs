using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Display;

public interface IDisplay
{
    void ShowText();
    void ReceiveText(string text);
    void SetColor(Color color);
}