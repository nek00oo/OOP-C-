using Models.Accounts;

namespace Contracts.Users;

public interface ICurrentUserService
{
    UserAccount? UserAccount { get; }
}