namespace Itmo.ObjectOrientedProgramming.Lab3.Type;

public abstract record LvlImportant
{
    private LvlImportant() { }

    public sealed record First : LvlImportant;
    public sealed record Second : LvlImportant;
    public sealed record Third : LvlImportant;
}