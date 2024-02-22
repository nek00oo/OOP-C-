namespace Contracts.Users;

public abstract record ToUpBalanceResult
{
    private ToUpBalanceResult() { }

    public sealed record Success(long CurrentBalance) : ToUpBalanceResult;

    public sealed record FailedTopUp : ToUpBalanceResult;
}