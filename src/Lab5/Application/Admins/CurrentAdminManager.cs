using Contracts.Admins;
using Models.Accounts;

namespace Application.Admins;

public class CurrentAdminManager : ICurrentAdminService
{
    public AdminAccount? AdminAccount { get; set; }
}