using Models.Accounts;

namespace Abstractions.Repositories;

public interface IAdminRepository
{
    public Task<AdminAccount?> FindAdminByPasswordAsync(string password);
    public Task<bool?> CreateUserAccount(long accountNumber, string accountPassword);
    public Task ChangePassword(string newPassword, long currentId);
}