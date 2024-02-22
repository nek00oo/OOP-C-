namespace Itmo.ObjectOrientedProgramming.Lab2.Type;

public abstract record PortType
{
    private PortType() { }

    public sealed record PciE() : PortType;

    public sealed record Sata() : PortType;
}