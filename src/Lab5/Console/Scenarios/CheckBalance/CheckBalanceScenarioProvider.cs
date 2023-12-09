using System.Diagnostics.CodeAnalysis;
using Contracts.Users;

namespace Console.Scenarios.CheckBalance;

public class CheckBalanceScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public CheckBalanceScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser?.UserAccount is not null)
        {
            scenario = new CheckBalanceScenario(_service, _currentUser.UserAccount.Id);
            return true;
        }

        scenario = null;
        return false;
    }
}