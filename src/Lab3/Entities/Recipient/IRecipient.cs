using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public interface IRecipient : IMessageReceiver
{
    MessageStatus GetMessageStatus();
    void TransferMessage();
}