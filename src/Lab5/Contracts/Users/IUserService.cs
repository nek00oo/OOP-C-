namespace Contracts.Users;

public interface IUserService
{
    LoginResult Login(long accountNumber, string password);
    ToUpBalanceResult ToUpAccountBalance(long amountMoney);
    MakeWithdrawalResult MakeWithdrawal(long amountMoney);
    CheckBalanceResult CheckBalance();
    CheckHistoryOperationResult CheckHistoryOperation();
}