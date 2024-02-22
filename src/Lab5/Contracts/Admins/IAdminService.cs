namespace Contracts.Admins;

public interface IAdminService
{
    AccessCheckResult Login(string password);
    CreateUserAccountResult CreateUserAccount(long accountNumber, string accountPassword);
    ChangePasswordResult ChangePassword(string newPassword);
}