using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class DisplayRecipient : IRecipient
{
    private IMessage? _message;
    private IReceiveMessageOnDisplay _displayAdapter;

    public DisplayRecipient(IReceiveMessageOnDisplay display)
    {
        _displayAdapter = display;
    }

    public MessageStatus GetMessageStatus()
    {
        if (_message != null)
            return new MessageStatus.Success(_message.Title);
        return new MessageStatus.MessageNotDelivered();
    }

    public void TransferMessage()
    {
        if (_message == null)
            throw new InvalidOperationException("message not detected");
        _displayAdapter.ReceiveMessage(_message);
    }

    public void ReceiveMessage(IMessage message) => _message = message;
}