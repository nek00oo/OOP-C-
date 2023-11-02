using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class RecipientImportanceShell : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly LvlImportant _lvlImportant;
    public RecipientImportanceShell(IRecipient recipient, LvlImportant lvlImportant)
    {
        _recipient = recipient;
        _lvlImportant = lvlImportant;
    }

    public void ReceiveMessage(IMessage message)
    {
        if (_lvlImportant == message.LvlImportant)
            _recipient.ReceiveMessage(message);
    }

    public MessageStatus GetMessageStatus() => _recipient.GetMessageStatus();

    public void TransferMessage() => _recipient.TransferMessage();
}