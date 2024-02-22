using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public abstract record ParseResult
{
    private ParseResult() { }

    public sealed record Success(ICommand Command) : ParseResult;

    public sealed record CommandNotDetected : ParseResult;
}