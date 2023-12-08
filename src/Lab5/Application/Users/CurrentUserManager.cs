using Contracts.Users;
using Models.Accounts;

namespace Application.Users;

internal class CurrentUserManager : ICurrentUserService
{
    public Account? UserAccount { get; set; }
}