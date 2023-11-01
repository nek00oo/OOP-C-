using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Models.User;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class UserRecipient : IRecipient
{
    private IUser _user;
    private IMessage? _message;
    public UserRecipient(IUser user)
    {
        _user = user;
    }

    public void TransferMessage()
    {
        if (_message == null)
            throw new InvalidOperationException("message not detected");
        _user.ReceiveMessage(_message);
    }

    public MessageStatus GetMessageStatus()
    {
        if (_message != null)
            return new MessageStatus.Success(_message.Title);
        return new MessageStatus.MessageNotDelivered();
    }

    public void ReceiveMessage(IMessage message) => _message = message;
}