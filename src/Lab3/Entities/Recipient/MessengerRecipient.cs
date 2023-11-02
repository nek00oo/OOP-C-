using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class MessengerRecipient : IRecipient
{
    private IReceiveMessageOnMessenger _messenger;
    private IMessage? _message;

    public MessengerRecipient(IReceiveMessageOnMessenger messenger)
    {
        _messenger = messenger;
    }

    public void TransferMessage()
    {
        if (_message == null)
            throw new InvalidOperationException("message not detected");
        _messenger.ReceiveMessage(_message);
    }

    public MessageStatus GetMessageStatus()
    {
        if (_message != null)
            return new MessageStatus.Success(_message.Title);
        return new MessageStatus.MessageNotDelivered();
    }

    public void ReceiveMessage(IMessage message) => _message = message;
}