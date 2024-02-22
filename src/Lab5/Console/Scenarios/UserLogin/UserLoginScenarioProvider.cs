using System.Diagnostics.CodeAnalysis;
using Contracts.Admins;
using Contracts.Users;

namespace Console.Scenarios.UserLogin;

public class UserLoginScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;
    private readonly ICurrentAdminService _currentAdmin;

    public UserLoginScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser,
        ICurrentAdminService currentAdmin)
    {
        _service = service;
        _currentUser = currentUser;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.UserAccount is null && _currentAdmin.AdminAccount is null)
        {
            scenario = new UserLoginScenario(_service);
            return true;
        }

        scenario = null;
        return false;
    }
}