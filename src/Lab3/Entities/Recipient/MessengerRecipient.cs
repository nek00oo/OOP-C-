using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class MessengerRecipient : IRecipient
{
    private IReceiveAndShowMessageOnMessenger _messenger;
    public MessengerRecipient(LvlImportant lvlImportant, IReceiveAndShowMessageOnMessenger messenger)
    {
        _messenger = messenger;
        LvlImportant = lvlImportant;
    }

    public LvlImportant LvlImportant { get; }
    public IMessage? Message { get; private set; }
    public void TransferMessage()
    {
        if (Message == null)
            throw new InvalidOperationException("message not detected");
        _messenger.ReceiveMessage(Message);
    }

    public MessageStatus GetMessageStatus()
    {
        if (Message != null)
            return new MessageStatus.Success(Message.Title);
        return new MessageStatus.MessageNotDelivered();
    }

    public void ReceiveMessage(IMessage message) => Message = message;
}