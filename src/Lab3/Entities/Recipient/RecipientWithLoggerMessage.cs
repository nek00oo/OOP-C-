using Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class RecipientWithLoggerMessage : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly ILogger _logger;

    public RecipientWithLoggerMessage(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public void ReceiveMessage(IMessage message)
    {
        _recipient.ReceiveMessage(message);
        _logger.ShowStatus(_recipient.GetMessageStatus(), _recipient);
    }

    public MessageStatus GetMessageStatus() => _recipient.GetMessageStatus();

    public void TransferMessage() => _recipient.TransferMessage();
}