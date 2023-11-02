using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Messenger;

public class MessengerAdapter : IReceiveMessageOnMessenger
{
    private IMessenger _messenger;
    public MessengerAdapter(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void ReceiveMessage(IMessage message) => _messenger.ReceiveText(message.Render());
}