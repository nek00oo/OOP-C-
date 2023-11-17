namespace Itmo.ObjectOrientedProgramming.Lab4;

public abstract record CommandArgument
{
    private CommandArgument() { }

    public sealed record Success(string Path) : CommandArgument;

    public sealed record CommandNotDetected : CommandArgument;
}