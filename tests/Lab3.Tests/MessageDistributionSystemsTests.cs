using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Topic;
using Itmo.ObjectOrientedProgramming.Lab3.Models.User;
using Itmo.ObjectOrientedProgramming.Lab3.Type;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessageDistributionSystemsTests
{
    [Fact]
    public void IsReadReceivedMessage_ReturnIsNotRead()
    {
        // Arrange
        var messageBuilder = new MessageBuilder();
        IMessage message = messageBuilder.SelectTitle("Title")
            .SelectContent("Content")
            .SetLvlImportantForMessage(new LvlImportant.Second())
            .Build();
        IUser user = new User();
        IRecipient userRecipient = new UserRecipient(user);
        IRecipientTopic topic = new RecipientTopic("topic", userRecipient);

        // Act
        topic.SendMessage(message);
        userRecipient.TransferMessage();

        // Assert
        Assert.False(user.IsMessageRead(message));
    }

    [Fact]
    public void MarkMessageIsRead_ReturnMessageIsRead()
    {
        // Arrange
        var messageBuilder = new MessageBuilder();
        IMessage message = messageBuilder.SelectTitle("Title")
            .SelectContent("Content")
            .SetLvlImportantForMessage(new LvlImportant.Second())
            .Build();
        IUser user = new User();
        IRecipient userRecipient = new UserRecipient(user);
        IRecipientTopic topic = new RecipientTopic("topic", userRecipient);

        // Act
        topic.SendMessage(message);
        userRecipient.TransferMessage();
        user.MarkMessageRead(message);

        // Assert
        Assert.True(user.IsMessageRead(message));
    }

    [Fact]
    public void MarkMessageIsRead_ReturnException()
    {
        // Arrange
        var messageBuilder = new MessageBuilder();
        IMessage message = messageBuilder.SelectTitle("Title")
            .SelectContent("Content")
            .SetLvlImportantForMessage(new LvlImportant.Second())
            .Build();
        IUser user = new User();
        IRecipient userRecipient = new UserRecipient(user);
        IRecipientTopic topic = new RecipientTopic("topic", userRecipient);

        // Act
        topic.SendMessage(message);
        userRecipient.TransferMessage();
        user.MarkMessageRead(message);

        // Assert
        Assert.Throws<InvalidOperationException>(() => user.MarkMessageRead(message));
    }

    [Fact]
    public void GetMessageStatus_ReturnMessageNotDelivered()
    {
        // Arrange
        var messageBuilder = new MessageBuilder();
        IMessage message = messageBuilder.SelectTitle("Title")
            .SelectContent("Content")
            .SetLvlImportantForMessage(new LvlImportant.Third())
            .Build();
        IUser user = new User();
        IRecipient userRecipient = new UserRecipient(user);
        var userRecipientImportanceShell = new RecipientImportanceShell(userRecipient, new LvlImportant.Second());
        IRecipientTopic topic = new RecipientTopic("topic", userRecipientImportanceShell);

        // Act
        topic.SendMessage(message);

        // Assert
        Assert.Equal(new MessageStatus.MessageNotDelivered(), userRecipient.GetMessageStatus());
    }

    [Fact]
    public void Logger_ReturnMessageStatus()
    {
        // Arrange
        var messageBuilder = new MessageBuilder();
        IMessage message = messageBuilder.SelectTitle("Title")
            .SelectContent("Content")
            .SetLvlImportantForMessage(new LvlImportant.Third())
            .Build();
        IMessenger messenger = new Messenger();
        IReceiveAndShowMessageOnMessenger messengerAdapter = new MessengerAdapter(messenger);
        IRecipient messengerRecipient = new MessengerRecipient(messengerAdapter);
        ILogger logger = new Logger();
        var messengerRecipientWithLoggerMessage = new RecipientWithLoggerMessage(messengerRecipient, logger);
        IRecipientTopic topic = new RecipientTopic("topic", messengerRecipientWithLoggerMessage);

        // Act
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        topic.SendMessage(message);

        // Assert
        string expectedOutput = "The message Title reached the MessengerRecipient\r\n";
        Assert.Equal(expectedOutput, stringWriter.ToString());
    }

    [Fact]
    public void WriteTextMessenger_ReturnText()
    {
        // Arrange
        var messageBuilder = new MessageBuilder();
        IMessage message = messageBuilder.SelectTitle("Title")
            .SelectContent("Content")
            .SetLvlImportantForMessage(new LvlImportant.Third())
            .Build();
        IMessenger messenger = new Messenger();
        IReceiveAndShowMessageOnMessenger messengerAdapter = new MessengerAdapter(messenger);
        IRecipient messengerRecipient = new MessengerRecipient(messengerAdapter);
        IRecipientTopic topic = new RecipientTopic("topic", messengerRecipient);

        // Act
        topic.SendMessage(message);
        messengerRecipient.TransferMessage();
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        messenger.WriteText();

        // Assert
        string expectedOutput = "Messenger:\nTitle\nContent\r\n";
        Assert.Equal(expectedOutput, stringWriter.ToString());
    }
}