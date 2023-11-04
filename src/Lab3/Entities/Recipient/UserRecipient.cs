using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Models.User;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class UserRecipient : IRecipient
{
    private readonly IUser _user;
    public UserRecipient(IUser user)
    {
        _user = user;
    }

    public void TransferMessage(IMessage message) => _user.ReceiveMessage(message);
}