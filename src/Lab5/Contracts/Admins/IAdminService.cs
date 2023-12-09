namespace Contracts.Admins;

public interface IAdminService
{
    AccessCheckResult Login(string password);
}