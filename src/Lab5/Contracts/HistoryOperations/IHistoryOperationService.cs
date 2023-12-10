using Contracts.Users;

namespace Contracts.HistoryOperations;

public interface IHistoryOperationService
{
    CheckHistoryOperationResult CheckHistoryOperation();
}