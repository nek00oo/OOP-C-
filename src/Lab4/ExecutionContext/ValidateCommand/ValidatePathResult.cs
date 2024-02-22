namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.ValidateCommand;

public abstract record ValidatePathResult
{
    private ValidatePathResult() { }

    public sealed record Success : ValidatePathResult;

    public sealed record NotExist(string Error) : ValidatePathResult;
}