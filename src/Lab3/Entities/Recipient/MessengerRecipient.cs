using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Messenger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class MessengerRecipient : IRecipient
{
    private readonly IMessenger _messenger;

    public MessengerRecipient(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void TransferMessage(IMessage message) => _messenger.WriteText(message.Render());
}