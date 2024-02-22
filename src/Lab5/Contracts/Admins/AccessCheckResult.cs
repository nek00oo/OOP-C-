namespace Contracts.Admins;

public abstract record AccessCheckResult
{
    private AccessCheckResult() { }

    public sealed record Success : AccessCheckResult;

    public sealed record IncorrectPassword : AccessCheckResult;
}