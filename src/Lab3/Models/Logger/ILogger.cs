using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;

public interface ILogger
{
    void GetStatus(IMessage? message, IRecipient recipient);
}