using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IReceiverMessage
{
    void ReceiveMessage(IMessage message);
}