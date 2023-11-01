using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class GroupRecipient : IRecipient
{
    private readonly List<IRecipient> _recipients;

    public GroupRecipient(LvlImportant lvlImportant, IRecipient recipient)
    {
        _recipients = new List<IRecipient> { recipient };
        LvlImportant = lvlImportant;
    }

    public LvlImportant LvlImportant { get; }
    public IMessage? Message { get; private set; }

    public MessageStatus GetMessageStatus()
    {
        throw new NotImplementedException();
    }

    public void TransferMessage()
    {
        if (Message == null)
            throw new InvalidOperationException("message not detected");
        foreach (IRecipient recipient in _recipients)
            recipient.ReceiveMessage(Message);
    }

    public void AddRecipient(IRecipient recipient)
    {
        _recipients.Add(recipient);
    }

    public void RemoveRecipient(IRecipient recipient)
    {
        _recipients.Remove(recipient);
    }

    public void ReceiveMessage(IMessage message) => Message = message;
}