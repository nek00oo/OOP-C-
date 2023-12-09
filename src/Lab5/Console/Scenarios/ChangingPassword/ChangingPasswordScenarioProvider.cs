using System.Diagnostics.CodeAnalysis;
using Contracts.Admins;
using Contracts.Users;
using Models.Accounts;

namespace Console.Scenarios.ChangingPassword;

public class ChangingPasswordScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentUserService _currentAdmin;

    public ChangingPasswordScenarioProvider(
        IAdminService service,
        ICurrentUserService currentAdmin)
    {
        _service = service;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.UserAccount?.Role is UserRole.Admin)
        {
            scenario = new ChangingPasswordScenario(_service, _currentAdmin.UserAccount.Id);
            return true;
        }

        scenario = null;
        return false;
    }
}