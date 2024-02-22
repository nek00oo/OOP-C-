using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.User;

public class User : IUser
{
    private readonly Dictionary<IMessage, bool> _readMessages;

    public User()
    {
        _readMessages = new Dictionary<IMessage, bool>();
    }

    public MessageStatus MarkMessageRead(IMessage message)
    {
        if (!_readMessages.ContainsKey(message) || _readMessages[message])
            return new MessageStatus.MessageAlreadyBeenRead();
        _readMessages[message] = true;
        return new MessageStatus.Success();
    }

    public bool IsMessageRead(IMessage message) => _readMessages.TryGetValue(message, out bool value) && value;

    public void ReceiveMessage(IMessage message) => _readMessages.Add(message, false);
}