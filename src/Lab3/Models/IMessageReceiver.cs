using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IMessageReceiver
{
    void ReceiveMessage(IMessage message);
}