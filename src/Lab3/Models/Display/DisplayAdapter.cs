using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Display;

public class DisplayAdapter : IReceiveAndShowMessageOnDisplay
{
    private IDisplay _display;
    public DisplayAdapter(IDisplay display)
    {
        _display = display;
    }

    public void ReceiveMessage(IMessage message) => _display.ReceiveText(message.Render());
    public void SetColor(Color color) => _display.SetColor(color);
    public void ShowMessage() => _display.ShowText();
}