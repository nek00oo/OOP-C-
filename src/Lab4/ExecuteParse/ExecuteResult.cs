namespace Itmo.ObjectOrientedProgramming.Lab4.ExecuteParse;

public abstract record ExecuteResult
{
    private ExecuteResult() { }

    public sealed record Success(string Complete) : ExecuteResult;

    public sealed record ExecutionError(string Error) : ExecuteResult;
}