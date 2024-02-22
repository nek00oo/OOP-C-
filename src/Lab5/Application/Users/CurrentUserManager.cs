using Contracts.Users;
using Models.Accounts;

namespace Application.Users;

internal class CurrentUserManager : ICurrentUserService
{
    public UserAccount? UserAccount { get; set; }
}