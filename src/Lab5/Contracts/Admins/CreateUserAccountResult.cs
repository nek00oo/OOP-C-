namespace Contracts.Admins;

public abstract record CreateUserAccountResult
{
    private CreateUserAccountResult() { }

    public sealed record Success : CreateUserAccountResult;

    public sealed record UserAlreadyExists : CreateUserAccountResult;
}