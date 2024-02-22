using Models.Accounts;

namespace Abstractions.Repositories;

public interface IUserRepository
{
    public Task<UserAccount?> FindAccountUserByAccountNumberAndPasswordAsync(long accountNumber, string password);
    public Task ToUpBalanceAsync(long id, long amountMoney);
    public Task MakeWithdrawalAsync(long id, long amountMoney);
    public Task<long?> CheckBalance(long id);
}