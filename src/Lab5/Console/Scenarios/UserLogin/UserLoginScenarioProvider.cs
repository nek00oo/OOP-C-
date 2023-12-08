using System.Diagnostics.CodeAnalysis;
using Contracts.Users;

namespace Console.Scenarios.UserLogin;

public class UserLoginScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public UserLoginScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.UserAccount is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new UserLoginScenario(_service);
        return true;
    }
}