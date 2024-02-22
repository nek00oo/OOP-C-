using Abstractions.Repositories;
using Application.Users;
using Contracts.HistoryOperations;
using Contracts.Users;
using Models.Operations;

namespace Application.Operations;

internal class HistoryOperationService : IHistoryOperationService
{
    private readonly IHistoryOperationRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public HistoryOperationService(IHistoryOperationRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public CheckHistoryOperationResult CheckHistoryOperation()
    {
        if (_currentUserManager.UserAccount == null)
            return new CheckHistoryOperationResult.ExecuteError();
        var operations = new List<Operation>();

        async Task ProcessAsync()
        {
            await foreach (Operation operation in _repository.CheckHistoryOperation(_currentUserManager.UserAccount.Id))
            {
                operations.Add(operation);
            }
        }

        Task.Run(ProcessAsync).Wait();

        if (operations.Count == 0)
            return new CheckHistoryOperationResult.ExecuteError();

        return new CheckHistoryOperationResult.Success(operations);
    }
}