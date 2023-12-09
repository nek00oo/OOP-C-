using System.Diagnostics.CodeAnalysis;
using Contracts.Admins;
using Contracts.Users;

namespace Console.Scenarios.AdminLogin;

public class AdminLoginProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentUserService _currentAdmin;

    public AdminLoginProvider(
        IAdminService service,
        ICurrentUserService currentAdmin)
    {
        _service = service;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.UserAccount is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLoginScenario(_service);
        return true;
    }
}