namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Messenger;

public interface IMessenger
{
    void WriteText();
    void ReceiveText(string text);
}