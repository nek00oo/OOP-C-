using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Topic;
using Itmo.ObjectOrientedProgramming.Lab3.Models.User;
using Itmo.ObjectOrientedProgramming.Lab3.Type;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessageDistributionSystemsTests
{
    [Fact]
    public void TestedMethodIsMessageRead_ExpectedResultFalse_WhenMessageIsNotRead()
    {
        // Arrange
        var messageBuilder = new MessageBuilder();
        IMessage message = messageBuilder.SelectTitle("Title")
            .SelectContent("Content")
            .SetLvlImportantForMessage(2)
            .Build();
        IUser user = new User();
        IRecipient userRecipient = new UserRecipient(user);
        IRecipientTopic topic = new RecipientTopic("topic", userRecipient);

        // Act
        topic.SendMessage(message);

        // Assert
        Assert.False(user.IsMessageRead(message));
    }

    [Fact]
    public void TestedMethodIsMessageRead_ExpectedResultTrue_WhenMessageIsRead()
    {
        // Arrange
        var messageBuilder = new MessageBuilder();
        IMessage message = messageBuilder.SelectTitle("Title")
            .SelectContent("Content")
            .SetLvlImportantForMessage(2)
            .Build();
        IUser user = new User();
        IRecipient userRecipient = new UserRecipient(user);
        IRecipientTopic topic = new RecipientTopic("topic", userRecipient);

        // Act
        topic.SendMessage(message);
        user.MarkMessageRead(message);

        // Assert
        Assert.True(user.IsMessageRead(message));
    }

    [Fact]
    public void TestedMethodMarkMessageIsRead_ExpectedResultMessageAlreadyBeenRead_WhenMessageIsRead()
    {
        // Arrange
        var messageBuilder = new MessageBuilder();
        IMessage message = messageBuilder.SelectTitle("Title")
            .SelectContent("Content")
            .SetLvlImportantForMessage(2)
            .Build();
        IUser user = new User();
        IRecipient userRecipient = new UserRecipient(user);
        IRecipientTopic topic = new RecipientTopic("topic", userRecipient);

        // Act
        topic.SendMessage(message);
        user.MarkMessageRead(message);

        // Assert
        Assert.Equal(new MessageStatus.MessageAlreadyBeenRead(), user.MarkMessageRead(message));
    }

    [Fact]
    public void TestedMethodTransferMessage_ExpectedResult_TestConditionSendMessage_ShouldBeIgnored_WhenPriorityIsLow()
    {
        // Arrange
        var messageBuilder = new MessageBuilder();
        IMessage message = messageBuilder.SelectTitle("Title")
            .SelectContent("Content")
            .SetLvlImportantForMessage(3)
            .Build();
        IRecipient userRecipient = Substitute.For<IRecipient>();
        var userRecipientImportanceShell = new RecipientImportanceShell(userRecipient, 2);
        IRecipientTopic topic = new RecipientTopic("topic", userRecipientImportanceShell);

        // Act
        topic.SendMessage(message);

        // Assert
        userRecipient.DidNotReceive().TransferMessage(message);
    }

    [Fact]
    public void Logger_ReturnMessageStatus()
    {
        // Arrange
        var messageBuilder = new MessageBuilder();
        IMessage message = messageBuilder.SelectTitle("Title")
            .SelectContent("Content")
            .SetLvlImportantForMessage(3)
            .Build();
        IMessenger messenger = new Messenger();
        IRecipient messengerRecipient = new MessengerRecipient(messenger);
        ILogger logger = Substitute.For<ILogger>();
        var messengerRecipientWithLoggerMessage = new RecipientWithLoggerMessage(messengerRecipient, logger);
        IRecipientTopic topic = new RecipientTopic("topic", messengerRecipientWithLoggerMessage);

        // Act
        topic.SendMessage(message);

        // Assert
        logger.Received().ShowStatus("Logger : The TransferMessage is called. MessengerRecipient");
    }

    [Fact]
    public void WriteTextMessenger_ReturnText()
    {
        // Arrange
        var messageBuilder = new MessageBuilder();
        IMessage message = messageBuilder.SelectTitle("Title")
            .SelectContent("Content")
            .SetLvlImportantForMessage(3)
            .Build();
        IMessenger messenger = Substitute.For<IMessenger>();
        IRecipient messengerRecipient = new MessengerRecipient(messenger);
        IRecipientTopic topic = new RecipientTopic("topic", messengerRecipient);

        // Act
        topic.SendMessage(message);

        // Assert
        messenger.Received().WriteText("Title\nContent");
    }
}