namespace Itmo.ObjectOrientedProgramming.Lab2.Type;

public abstract record SocketType
{
    private SocketType() { }

    public sealed record Am4() : SocketType;

    public sealed record Lga775() : SocketType;

    public sealed record Fm2() : SocketType;

    public sealed record Lga2066() : SocketType;
}