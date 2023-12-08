using Models.Accounts;

namespace Contracts.Users;

public interface ICurrentUserService
{
    Account? UserAccount { get; }
}