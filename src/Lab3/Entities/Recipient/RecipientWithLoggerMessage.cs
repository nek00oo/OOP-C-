using Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

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

    public void TransferMessage(IMessage message)
    {
        _logger.ShowStatus($"Logger : The TransferMessage is called. {_recipient.GetType().Name}");
        _recipient.TransferMessage(message);
    }
}