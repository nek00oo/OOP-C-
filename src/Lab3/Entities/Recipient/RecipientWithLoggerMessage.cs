using Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class RecipientWithLoggerMessage : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly ILogger _logger;

    public RecipientWithLoggerMessage(IRecipient recipient, ILogger logger, IMessage? message)
    {
        _recipient = recipient;
        _logger = logger;
        Message = message;
    }

    public IMessage? Message { get; }

    public void ReceiveMessage(IMessage message)
    {
        _recipient.ReceiveMessage(message);
        _logger.ShowStatus(_recipient.GetMessageStatus(), _recipient);
    }

    public MessageStatus GetMessageStatus() => _recipient.GetMessageStatus();

    public void TransferMessage() => _recipient.TransferMessage();
}