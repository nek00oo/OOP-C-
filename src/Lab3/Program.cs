using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Topic;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public static class Program
{
    public static void Main()
    {
        var messageBuildeer = new MessageBuilder();
        IMessage message = messageBuildeer.SelectTitle("Title")
            .SelectContent("Content")
            .SetLvlImportantForMessage(2)
            .Build();
        IMessenger messenger = new Messenger();
        IRecipient messengerRecipient = new MessengerRecipient(messenger);
        ILogger logger = new Logger();
        var messengerRecipientWithLoggerMessage = new RecipientWithLoggerMessage(messengerRecipient, logger);
        IRecipientTopic topic = new RecipientTopic("topic", messengerRecipientWithLoggerMessage);
        topic.SendMessage(message);
    }
}