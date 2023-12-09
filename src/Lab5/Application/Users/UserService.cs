using Abstractions.Repositories;
using Contracts.Users;
using Models.Accounts;
using Models.Operations;

namespace Application.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public LoginResult Login(long accountNumber, string password)
    {
        Task<UserAccount?> user = _repository.FindAccountUserByAccountNumberAndPasswordAsync(accountNumber, password);
        if (user.Result is null)
            return new LoginResult.NotFound();

        _currentUserManager.UserAccount = user.Result;
        return new LoginResult.Success();
    }

    public ToUpBalanceResult ToUpAccountBalance(long id, long amountMoney)
    {
        long? result = _repository.ToUpBalanceAsync(id, amountMoney).Result;
        if (result is null)
            return new ToUpBalanceResult.FailedTopUp();

        return new ToUpBalanceResult.Success(result.Value);
    }

    public MakeWithdrawalResult MakeWithdrawal(long id, long amountMoney)
    {
        Task<MakeWithdrawalResult?> result = _repository.MakeWithdrawalAsync(id, amountMoney);
        if (result.Result is null)
            return new MakeWithdrawalResult.OperationMakeWithdrawalError();

        return result.Result;
    }

    public CheckBalanceResult CheckBalance(long id)
    {
        long? balance = _repository.CheckBalance(id).Result;
        if (balance is null)
            return new CheckBalanceResult.NotFoundAccount();

        return new CheckBalanceResult.Success((long)balance);
    }

    public CheckHistoryOperationResult CheckHistoryOperation(long accountId)
    {
        var operations = new List<Operation>();

        async Task ProcessAsync()
        {
            await foreach (Operation operation in _repository.CheckHistoryOperation(accountId))
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