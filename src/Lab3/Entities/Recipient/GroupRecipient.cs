using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class GroupRecipient : IRecipient
{
    private readonly List<IRecipient> _recipients;
    private IMessage? _message;
    public GroupRecipient(IRecipient recipient)
    {
        _recipients = new List<IRecipient> { recipient };
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
        foreach (IRecipient recipient in _recipients)
            recipient.ReceiveMessage(_message);
    }

    public void AddRecipient(IRecipient recipient) => _recipients.Add(recipient);
    public void RemoveRecipient(IRecipient recipient) => _recipients.Remove(recipient);
    public void ReceiveMessage(IMessage message) => _message = message;
}