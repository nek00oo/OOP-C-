using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Topic;

public interface IRecipientTopic
{
    void SendMessage(IMessage message);
}