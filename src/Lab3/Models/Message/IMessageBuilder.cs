namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

public interface IMessageBuilder
{
    IMessageBuilder SelectTitle(string title);
    IMessageBuilder SelectContent(string content);
    IMessageBuilder SetLvlImportantForMessage(int lvlImportant);
    IMessage Build();
}