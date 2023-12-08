using System.Diagnostics.CodeAnalysis;
using Contracts.Users;

namespace Console.Scenarios.ToUpBalance;

public class ToUpBalanceScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public ToUpBalanceScenarioProvider(
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
            scenario = new ToUpBalanceScenario(_service, _currentUser.UserAccount.Id);
            return true;
        }

        scenario = null;
        return false;
    }
}