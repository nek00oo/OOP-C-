namespace Itmo.ObjectOrientedProgramming.Lab2.Type;

public abstract record RamMemoryFormFactor
{
    private RamMemoryFormFactor() { }

    public sealed record Dip() : RamMemoryFormFactor;

    public sealed record Simm30() : RamMemoryFormFactor;

    public sealed record Simm72() : RamMemoryFormFactor;

    public sealed record Dimm168() : RamMemoryFormFactor;

    public sealed record Dimm184() : RamMemoryFormFactor;
}