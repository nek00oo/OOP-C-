using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class GroupRecipient : IRecipient
{
    private readonly IList<IRecipient> _recipients;
    public GroupRecipient(IList<IRecipient> recipients)
    {
        _recipients = recipients;
    }

    public void TransferMessage(IMessage message)
    {
        foreach (IRecipient recipient in _recipients)
            recipient.TransferMessage(message);
    }
}