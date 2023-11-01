using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;

public interface ILogger
{
    void ShowStatus(MessageStatus messageStatus, IRecipient recipient);
}