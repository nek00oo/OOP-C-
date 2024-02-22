using Models.Operations;

namespace Abstractions.Repositories;

public interface IHistoryOperationRepository
{
    IAsyncEnumerable<Operation> CheckHistoryOperation(long accountId);
    Task<Operation> AddHistoryOperation(long accountId, string textOperation);
}