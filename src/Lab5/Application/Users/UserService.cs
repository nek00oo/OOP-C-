using Abstractions.Repositories;
using Contracts.Users;
using Models.Accounts;

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
        Task<Account?> user = _repository.FindAccountUserByAccountNumberAndPasswordAsync(accountNumber, password);
        if (user.Result is null)
            return new LoginResult.NotFound();

        _currentUserManager.UserAccount = user.Result;
        return new LoginResult.Success();
    }

    public ToUpBalanceResult ToUpAccountBalance(long id, long amountMoney)
    {
        if (_repository.ToUpBalance(id, amountMoney).Result is false)
            return new ToUpBalanceResult.FailedTopUp();

        return new ToUpBalanceResult.Success();
    }
}