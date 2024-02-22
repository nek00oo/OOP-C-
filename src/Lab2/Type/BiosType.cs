namespace Itmo.ObjectOrientedProgramming.Lab2.Type;

public abstract record BiosType
{
    private BiosType() { }

    public sealed record AmiBios() : BiosType;

    public sealed record PhoenixBios() : BiosType;

    public sealed record IntelBios() : BiosType;

    public sealed record UefiBios() : BiosType;
}