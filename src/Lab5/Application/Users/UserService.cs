using Abstractions.Repositories;
using Contracts.Users;
using Models.Accounts;
using Models.Operations;

namespace Application.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IHistoryOperationRepository _historyOperationRepository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(
        IUserRepository repository,
        CurrentUserManager currentUserManager,
        IHistoryOperationRepository historyOperationRepository)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
        _historyOperationRepository = historyOperationRepository;
    }

    public LoginResult Login(long accountNumber, string password)
    {
        Task<UserAccount?> user = _repository.FindAccountUserByAccountNumberAndPasswordAsync(accountNumber, password);
        if (user.Result is null)
            return new LoginResult.NotFound();

        _currentUserManager.UserAccount = user.Result;
        Task<Operation> historyResult = _historyOperationRepository.AddHistoryOperation(user.Result.Id, "Login");
        historyResult.Wait();
        return new LoginResult.Success();
    }

    public ToUpBalanceResult ToUpAccountBalance(long amountMoney)
    {
        if (_currentUserManager.UserAccount == null)
            return new ToUpBalanceResult.FailedTopUp();
        Task result = _repository.ToUpBalanceAsync(_currentUserManager.UserAccount.Id, amountMoney);
        result.Wait();
        Task<Operation> historyResult = _historyOperationRepository.AddHistoryOperation(_currentUserManager.UserAccount.Id, "To up balance");
        historyResult.Wait();
        long currentMoney = 0;
        if (CheckBalance() is CheckBalanceResult.Success success)
            currentMoney = success.Balance;

        return new ToUpBalanceResult.Success(currentMoney);
    }

    public MakeWithdrawalResult MakeWithdrawal(long amountMoney)
    {
        if (_currentUserManager.UserAccount == null)
            return new MakeWithdrawalResult.OperationMakeWithdrawalError();
        long currentMoney = 0;
        if (CheckBalance() is CheckBalanceResult.Success success)
            currentMoney = success.Balance;
        if (currentMoney < amountMoney)
            return new MakeWithdrawalResult.NotEnoughMoneyInAccount();
        Task result = _repository.MakeWithdrawalAsync(_currentUserManager.UserAccount.Id, amountMoney);
        result.Wait();
        Task<Operation> historyResult = _historyOperationRepository.AddHistoryOperation(_currentUserManager.UserAccount.Id, "make withdrawal");
        historyResult.Wait();
        return new MakeWithdrawalResult.Success(currentMoney - amountMoney);
    }

    public CheckBalanceResult CheckBalance()
    {
        if (_currentUserManager.UserAccount == null)
            return new CheckBalanceResult.NotFoundAccount();
        Task<long?> balance = _repository.CheckBalance(_currentUserManager.UserAccount.Id);
        if (balance.Result is null)
            return new CheckBalanceResult.NotFoundAccount();
        Task<Operation> historyResult = _historyOperationRepository.AddHistoryOperation(_currentUserManager.UserAccount.Id, "check balance");
        historyResult.Wait();
        return new CheckBalanceResult.Success((long)balance.Result);
    }
}