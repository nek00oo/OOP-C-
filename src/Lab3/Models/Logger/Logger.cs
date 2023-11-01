using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Type;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Logger;

public class Logger : ILogger
{
    public void ShowStatus(MessageStatus messageStatus, IRecipient recipient)
    {
        if (messageStatus is MessageStatus.Success success)
        {
            Console.WriteLine($"The message {success.TitleMessage} reached the {recipient.GetType().Name}");
            return;
        }

        Console.WriteLine($"The message did not reach the {recipient.GetType().Name}");
    }
}