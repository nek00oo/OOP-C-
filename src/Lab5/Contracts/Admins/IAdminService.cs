using Contracts.Users;

namespace Contracts.Admins;

public interface IAdminService
{
    LoginResult Login(string password);
}