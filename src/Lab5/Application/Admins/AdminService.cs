using Abstractions.Repositories;
using Contracts.Admins;
using Models.Accounts;

namespace Application.Admins;

internal class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;
    private readonly CurrentAdminManager _currentAdminManager;

    public AdminService(IAdminRepository repository, CurrentAdminManager currentUserManager)
    {
        _repository = repository;
        _currentAdminManager = currentUserManager;
    }

    public AccessCheckResult Login(string password)
    {
        Task<AdminAccount?> admin = _repository.FindAdminByPasswordAsync(password);
        if (admin.Result is null)
            return new AccessCheckResult.IncorrectPassword();

        _currentAdminManager.AdminAccount = admin.Result;
        return new AccessCheckResult.Success();
    }

    public CreateUserAccountResult CreateUserAccount(long accountNumber, string accountPassword)
    {
        Task<bool?> result = _repository.CreateUserAccount(accountNumber, accountPassword);
        if (result.Result is false)
            return new CreateUserAccountResult.UserAlreadyExists();

        return new CreateUserAccountResult.Success();
    }

    public ChangePasswordResult ChangePassword(string newPassword)
    {
        if (_currentAdminManager.AdminAccount is null)
            return new ChangePasswordResult.ExecuteError();
        _repository.ChangePassword(newPassword, _currentAdminManager.AdminAccount.Id);
        return new ChangePasswordResult.Success();
    }
}