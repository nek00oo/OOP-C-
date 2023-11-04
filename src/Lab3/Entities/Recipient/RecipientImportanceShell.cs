using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class RecipientImportanceShell : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly int _lvlImportant;
    public RecipientImportanceShell(IRecipient recipient, int lvlImportant)
    {
        _recipient = recipient;
        if (lvlImportant < 0)
            throw new InvalidOperationException("The importance level should not be negative");
        _lvlImportant = lvlImportant;
    }

    public void TransferMessage(IMessage message)
    {
        if (_lvlImportant >= message.LvlImportant)
            _recipient.TransferMessage(message);
    }
}