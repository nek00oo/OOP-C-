namespace Itmo.ObjectOrientedProgramming.Lab2.Type;

public abstract record MotherboardFormFactorType
{
    private MotherboardFormFactorType() { }

    public sealed record EAtx() : MotherboardFormFactorType;

    public sealed record StandardAtx() : MotherboardFormFactorType;

    public sealed record MicroAtx() : MotherboardFormFactorType;

    public sealed record MiniItx() : MotherboardFormFactorType;

    public sealed record MiniStx() : MotherboardFormFactorType;
}