namespace Contracts.Admins;

public abstract record ChangePasswordResult
{
    private ChangePasswordResult() { }

    public sealed record Success : ChangePasswordResult;

    public sealed record ExecuteError : ChangePasswordResult;
}