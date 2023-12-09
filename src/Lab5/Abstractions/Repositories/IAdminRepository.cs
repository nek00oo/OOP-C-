using Models.Accounts;

namespace Abstractions.Repositories;

public interface IAdminRepository
{
    public Task<UserAccount?> FindAdminByPasswordAsync(string password);
}