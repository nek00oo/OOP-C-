using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Display;

public interface IDisplayDriver
{
    void ClearOutput();
    void SetColor(Color color);
    void OutputText(string text);
}