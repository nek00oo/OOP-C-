using System;
using System.Drawing;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Display;

public class DisplayAdapter : IReceiveAndShowMessageOnDisplay
{
    private IDisplay _display;
    private IMessage? _message;
    public DisplayAdapter(IDisplay display)
    {
        _display = display;
    }

    public void ReceiveMessage(IMessage message) => _message = message;

    public void SetColor(Color color) => _display.SetColor(color);

    public void ShowMessage()
    {
        if (_message == null)
            throw new InvalidOperationException("The message is missing");
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(_message.Title)
            .Append('\n')
            .Append(_message.Content);
        _display.ShowText(stringBuilder.ToString());
    }
}