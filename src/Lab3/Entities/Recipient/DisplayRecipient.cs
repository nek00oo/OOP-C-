using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class DisplayRecipient : IRecipient
{
    private IReceiveAndShowMessageOnDisplay _displayAdapter;
    public DisplayRecipient(LvlImportant lvlImportant, IReceiveAndShowMessageOnDisplay display)
    {
        _displayAdapter = display;
        LvlImportant = lvlImportant;
    }

    public LvlImportant LvlImportant { get; }
    public IMessage? Message { get; private set; }
    public MessageStatus GetMessageStatus()
    {
        if (Message != null)
            return new MessageStatus.Success(Message.Title);
        return new MessageStatus.MessageNotDelivered();
    }

    public void TransferMessage()
    {
        if (Message == null)
            throw new InvalidOperationException("message not detected");
        _displayAdapter.ReceiveMessage(Message);
    }

    public void ReceiveMessage(IMessage message) => Message = message;
}