using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Messenger;

public class MessengerAdapter : IReceiveAndShowMessageOnMessenger
{
    private IMessenger _messenger;
    private IMessage? _message;

    public MessengerAdapter(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void ReceiveMessage(IMessage message) => _message = message;

    public void ShowMessage()
    {
        if (_message == null)
            throw new InvalidOperationException("The message is missing");
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(_message.Title)
            .Append('\n')
            .Append(_message.Content);
        _messenger.WriteText(stringBuilder.ToString());
    }
}