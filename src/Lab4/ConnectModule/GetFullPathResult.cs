namespace Itmo.ObjectOrientedProgramming.Lab4.ConnectModule;

public abstract record GetFullPathResult
{
    private GetFullPathResult() { }

    public sealed record Success(string FullPath) : GetFullPathResult;

    public sealed record ExecutionError : GetFullPathResult;
}