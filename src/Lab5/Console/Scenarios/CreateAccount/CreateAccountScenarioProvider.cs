using System.Diagnostics.CodeAnalysis;
using Contracts.Admins;
using Contracts.Users;
using Models.Accounts;

namespace Console.Scenarios.CreateAccount;

public class CreateAccountScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentUserService _currentAdmin;

    public CreateAccountScenarioProvider(
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
            scenario = new CreateAccountScenario(_service);
            return true;
        }

        scenario = null;
        return false;
    }
}