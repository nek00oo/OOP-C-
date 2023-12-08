namespace Contracts.Users;

public abstract record ToUpBalanceResult
{
    private ToUpBalanceResult() { }

    public sealed record Success : ToUpBalanceResult;

    public sealed record FailedTopUp : ToUpBalanceResult;
}