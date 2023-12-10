using Models.Accounts;

namespace Contracts.Admins;

public interface ICurrentAdminService
{
    AdminAccount? AdminAccount { get; }
}