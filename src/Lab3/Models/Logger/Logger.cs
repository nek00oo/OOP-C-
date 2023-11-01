using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;

public class Logger : ILogger
{
    public void GetStatus(IMessage? message, IRecipient recipient)
    {
        if (message == null)
        {
            Console.WriteLine($"The message did not reach the {recipient.GetType().Name}");
            return;
        }

        Console.WriteLine($"The message {message.Title} reached the {recipient.GetType().Name}");
    }
}