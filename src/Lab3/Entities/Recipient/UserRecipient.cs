using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Models.User;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class UserRecipient : IRecipient
{
    private IUser _user;

    public UserRecipient(LvlImportant lvlImportant, IUser user)
    {
        _user = user;
        LvlImportant = lvlImportant;
    }

    public LvlImportant LvlImportant { get; }
    public IMessage? Message { get; private set; }

    public void TransferMessage()
    {
        if (Message == null)
            throw new InvalidOperationException("message not detected");
        _user.ReceiveMessage(Message);
    }

    public MessageStatus GetMessageStatus()
    {
        if (Message != null)
            return new MessageStatus.Success(Message.Title);
        return new MessageStatus.MessageNotDelivered();
    }

    public void ReceiveMessage(IMessage message) => Message = message;
}