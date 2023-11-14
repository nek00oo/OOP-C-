namespace Itmo.ObjectOrientedProgramming.Lab4.ConnectModule;

public abstract record ConnectResult
{
    private ConnectResult() { }

    public sealed record Success : ConnectResult;
    public sealed record ConnectionError : ConnectResult;

    public sealed record ExecutionError : ConnectResult;
}