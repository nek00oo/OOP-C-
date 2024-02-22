using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.User;

public interface IUser : IReceiverMessage
{
    MessageStatus MarkMessageRead(IMessage message);
    bool IsMessageRead(IMessage message);
}