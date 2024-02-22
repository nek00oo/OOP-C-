namespace Itmo.ObjectOrientedProgramming.Lab2.Type;

public abstract record VersionBios
{
    private VersionBios() { }

    public sealed record F3() : VersionBios;
}