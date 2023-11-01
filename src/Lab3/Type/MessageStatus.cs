namespace Itmo.ObjectOrientedProgramming.Lab3.Type;

public abstract record MessageStatus
{
    private MessageStatus() { }

    public sealed record Success(string TitleMessage) : MessageStatus;

    public sealed record MessageNotDelivered : MessageStatus;
}