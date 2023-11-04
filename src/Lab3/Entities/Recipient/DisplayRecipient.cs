using Itmo.ObjectOrientedProgramming.Lab3.Models.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;

public class DisplayRecipient : IRecipient
{
    private readonly IDisplay _display;

    public DisplayRecipient(IDisplay display)
    {
        _display = display;
    }

    public void TransferMessage(IMessage message) => _display.ShowText(message.Render());
}