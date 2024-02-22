using System.Diagnostics.CodeAnalysis;
using Contracts.Admins;

namespace Console.Scenarios.CreateAccount;

public class CreateAccountScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentAdminService _currentAdmin;

    public CreateAccountScenarioProvider(
        IAdminService service,
        ICurrentAdminService currentAdmin)
    {
        _service = service;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.AdminAccount is not null)
        {
            scenario = new CreateAccountScenario(_service);
            return true;
        }

        scenario = null;
        return false;
    }
}