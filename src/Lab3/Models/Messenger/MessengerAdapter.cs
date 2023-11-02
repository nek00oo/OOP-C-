using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Messenger;

public class MessengerAdapter : IReceiveAndShowMessageOnMessenger
{
    private IMessenger _messenger;
    public MessengerAdapter(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void ReceiveMessage(IMessage message)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(message.Title)
            .Append(message.Content);
        _messenger.ReceiveText(stringBuilder.ToString());
    }

    public void ShowMessage() => _messenger.WriteText();
}