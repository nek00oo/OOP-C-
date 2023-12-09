namespace Contracts.Users;

public interface IUserService
{
    LoginResult Login(long accountNumber, string password);
    ToUpBalanceResult ToUpAccountBalance(long id, long amountMoney);
    MakeWithdrawalResult MakeWithdrawal(long id, long amountMoney);
    CheckBalanceResult CheckBalance(long id);
}