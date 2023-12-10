using System.Diagnostics.CodeAnalysis;
using Contracts.Admins;
using Models.Accounts;

namespace Console.Scenarios.ChangingPassword;

public class ChangingPasswordScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentAdminService _currentAdmin;

    public ChangingPasswordScenarioProvider(
        IAdminService service,
        ICurrentAdminService currentAdmin)
    {
        _service = service;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.AdminAccount?.Role is UserRole.Admin)
        {
            scenario = new ChangingPasswordScenario(_service);
            return true;
        }

        scenario = null;
        return false;
    }
}