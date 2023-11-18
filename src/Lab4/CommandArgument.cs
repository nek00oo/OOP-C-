using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public abstract record CommandArgument
{
    private CommandArgument() { }

    public sealed record Success(ICommand Command) : CommandArgument;

    public sealed record CommandNotDetected : CommandArgument;
}