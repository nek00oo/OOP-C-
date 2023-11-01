namespace Itmo.ObjectOrientedProgramming.Lab3.Type;

public abstract record MessageLogger
{
    private MessageLogger() { }

    public sealed record Success : MessageLogger;

    public sealed record MessageNotDelivered : MessageLogger;
}