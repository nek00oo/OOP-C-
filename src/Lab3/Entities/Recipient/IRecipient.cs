using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public interface IRecipient
{
    void TransferMessage(IMessage message);
}