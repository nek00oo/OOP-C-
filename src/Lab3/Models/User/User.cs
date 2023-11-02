using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.User;

public class User : IUser
{
    private readonly Dictionary<IMessage, bool> _readMessages;

    public User()
    {
        _readMessages = new Dictionary<IMessage, bool>();
    }

    public void MarkMessageRead(IMessage message)
    {
        if (!_readMessages.ContainsKey(message) || _readMessages[message])
            throw new InvalidOperationException("This message has already been marked as read");
        _readMessages[message] = true;
    }

    public bool IsMessageRead(IMessage message) => _readMessages.TryGetValue(message, out bool value) && value;

    public void ReceiveMessage(IMessage message) => _readMessages.Add(message, false);
}