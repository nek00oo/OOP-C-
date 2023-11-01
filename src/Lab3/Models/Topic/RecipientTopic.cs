using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Topic;

public class RecipientTopic : IRecipientTopic
{
    public RecipientTopic(string title, IRecipient recipient)
    {
        Title = title;
        Recipient = recipient;
    }

    public string Title { get; }
    public IRecipient Recipient { get; }

    public void SendMessage(IMessage message)
    {
        Recipient.ReceiveMessage(message);
    }
}