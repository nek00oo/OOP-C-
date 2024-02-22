namespace Itmo.ObjectOrientedProgramming.Lab2.Type;

public abstract record DdrType
{
    private DdrType() { }

    public sealed record V1() : DdrType;

    public sealed record V2() : DdrType;

    public sealed record V3() : DdrType;

    public sealed record V4() : DdrType;

    public sealed record V5() : DdrType;
}