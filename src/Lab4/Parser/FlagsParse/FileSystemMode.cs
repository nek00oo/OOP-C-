namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

public abstract record FileSystemMode
{
    private FileSystemMode() { }

    public sealed record Local : FileSystemMode;
}