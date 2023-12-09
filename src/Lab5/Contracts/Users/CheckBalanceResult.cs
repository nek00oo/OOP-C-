namespace Contracts.Users;

public abstract record CheckBalanceResult
{
    private CheckBalanceResult() { }

    public sealed record Success(long Balance) : CheckBalanceResult;

    public sealed record NotFoundAccount() : CheckBalanceResult;
}