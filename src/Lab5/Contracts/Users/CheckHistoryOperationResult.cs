using Models.Operations;

namespace Contracts.Users;

public abstract record CheckHistoryOperationResult
{
    private CheckHistoryOperationResult() { }

    public sealed record Success(IList<Operation> Operation) : CheckHistoryOperationResult;

    public sealed record ExecuteError : CheckHistoryOperationResult;
}