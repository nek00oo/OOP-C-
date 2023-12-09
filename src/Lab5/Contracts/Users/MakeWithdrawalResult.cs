namespace Contracts.Users;

public abstract record MakeWithdrawalResult
{
    private MakeWithdrawalResult() { }

    public sealed record Success(long CurrentBalance) : MakeWithdrawalResult;

    public sealed record NotEnoughMoneyInAccount : MakeWithdrawalResult;

    public sealed record OperationMakeWithdrawalError : MakeWithdrawalResult;
}