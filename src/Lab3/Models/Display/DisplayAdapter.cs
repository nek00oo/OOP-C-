using System.Drawing;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Display;

public class DisplayAdapter : IReceiveAndShowMessageOnDisplay
{
    private IDisplay _display;
    public DisplayAdapter(IDisplay display)
    {
        _display = display;
    }

    public void ReceiveMessage(IMessage message)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(message.Title)
            .Append(message.Content);
        _display.ReceiveText(stringBuilder.ToString());
    }

    public void SetColor(Color color) => _display.SetColor(color);

    public void ShowMessage() => _display.ShowText();
}