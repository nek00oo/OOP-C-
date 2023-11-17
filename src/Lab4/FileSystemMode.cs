namespace Itmo.ObjectOrientedProgramming.Lab4;

public abstract record FileSystemMode
{
    private FileSystemMode() { }

    public sealed record Local : FileSystemMode;
}