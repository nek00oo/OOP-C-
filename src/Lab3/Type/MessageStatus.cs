namespace Itmo.ObjectOrientedProgramming.Lab3.Type;

public abstract record MessageStatus
{
    private MessageStatus() { }

    public sealed record Success() : MessageStatus;
    public sealed record MessageAlreadyBeenRead : MessageStatus;
}