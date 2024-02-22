namespace Itmo.ObjectOrientedProgramming.Lab2.Type;

public abstract record PciEVersion
{
    private PciEVersion() { }

    public sealed record V16() : PciEVersion;

    public sealed record V4() : PciEVersion;

    public sealed record V2() : PciEVersion;

    public sealed record X() : PciEVersion;

    public sealed record Agp() : PciEVersion;
}