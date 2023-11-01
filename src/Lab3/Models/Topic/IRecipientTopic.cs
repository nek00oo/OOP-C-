using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Topic;

public interface IRecipientTopic
{
    public IRecipient Recipient { get; }
    void SendMessage(IMessage message);
}