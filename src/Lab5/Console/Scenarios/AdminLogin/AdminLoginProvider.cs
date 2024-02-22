using System.Diagnostics.CodeAnalysis;
using Contracts.Admins;
using Contracts.Users;

namespace Console.Scenarios.AdminLogin;

public class AdminLoginProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentUserService _currentUser;
    private readonly ICurrentAdminService _currentAdmin;

    public AdminLoginProvider(
        IAdminService service,
        ICurrentAdminService currentAdmin,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentAdmin = currentAdmin;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.AdminAccount is null && _currentUser.UserAccount is null)
        {
            scenario = new AdminLoginScenario(_service);
            return true;
        }

        scenario = null;
        return false;
    }
}