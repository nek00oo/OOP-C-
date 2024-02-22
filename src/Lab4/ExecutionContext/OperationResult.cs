namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

public abstract record OperationResult
{
    private OperationResult() { }

    public sealed record Success(IExecuteContext ExecuteContext) : OperationResult;
    public sealed record ExecutionError(string Error) : OperationResult;
}