using Models.Accounts;
namespace Abstractions.Repositories;

public interface IUserRepository
{
    public Task<Account?> FindAccountUserByAccountNumberAndPasswordAsync(long accountNumber, string password);
    public Task<bool> ToUpBalance(long id, long amountMoney);
}