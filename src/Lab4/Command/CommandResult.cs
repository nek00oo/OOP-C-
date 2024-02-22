namespace Itmo.ObjectOrientedProgramming.Lab4.Command;

public abstract record CommandResult
{
    private CommandResult() { }

    public sealed record Success(string? CurrentPath) : CommandResult;
    public sealed record ConnectionError : CommandResult;
    public sealed record ExecutionError : CommandResult;
}