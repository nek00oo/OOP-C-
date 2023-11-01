using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public interface IRecipient : IMessageReceiver
{
    public IMessage? Message { get; }
    void TransferMessage();
}