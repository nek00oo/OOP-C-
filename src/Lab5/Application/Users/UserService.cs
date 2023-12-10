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

    public ToUpBalanceResult ToUpAccountBalance(long amountMoney)
    {
        if (_currentUserManager.UserAccount == null)
            return new ToUpBalanceResult.FailedTopUp();
        long? result = _repository.ToUpBalanceAsync(_currentUserManager.UserAccount.Id, amountMoney).Result;

        if (result is null)
            return new ToUpBalanceResult.FailedTopUp();

        return new ToUpBalanceResult.Success(result.Value);
    }

    public MakeWithdrawalResult MakeWithdrawal(long amountMoney)
    {
        if (_currentUserManager.UserAccount == null)
            return new MakeWithdrawalResult.OperationMakeWithdrawalError();
        Task<MakeWithdrawalResult?> result = _repository.MakeWithdrawalAsync(_currentUserManager.UserAccount.Id, amountMoney);
        if (result.Result is null)
            return new MakeWithdrawalResult.OperationMakeWithdrawalError();

        return result.Result;
    }

    public CheckBalanceResult CheckBalance()
    {
        if (_currentUserManager.UserAccount == null)
            return new CheckBalanceResult.NotFoundAccount();
        long? balance = _repository.CheckBalance(_currentUserManager.UserAccount.Id).Result;
        if (balance is null)
            return new CheckBalanceResult.NotFoundAccount();

        return new CheckBalanceResult.Success((long)balance);
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

    private bool IsLogin() => _currentUserManager.UserAccount != null;
}