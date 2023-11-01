using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class RecipientImportanceShell : IRecipient
{
    private IRecipient _recipient;

    protected RecipientImportanceShell(IRecipient recipient, LvlImportant lvlImportant)
    {
        _recipient = recipient;
        LvlImportant = lvlImportant;
    }

    public LvlImportant LvlImportant { get; }

    public void ReceiveMessage(IMessage message)
    {
        if (LvlImportant == message.LvlImportant)
            _recipient.ReceiveMessage(message);
    }

    public MessageStatus GetMessageStatus() => _recipient.GetMessageStatus();

    public void TransferMessage() => _recipient.TransferMessage();
}