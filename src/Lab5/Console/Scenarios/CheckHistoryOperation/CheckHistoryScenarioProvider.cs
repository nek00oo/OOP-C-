using System.Diagnostics.CodeAnalysis;
using Contracts.HistoryOperations;
using Contracts.Users;

namespace Console.Scenarios.CheckHistoryOperation;

public class CheckHistoryScenarioProvider : IScenarioProvider
{
    private readonly IHistoryOperationService _service;
    private readonly ICurrentUserService _currentUser;

    public CheckHistoryScenarioProvider(
        IHistoryOperationService service,
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
            scenario = new CheckHistoryScenario(_service);
            return true;
        }

        scenario = null;
        return false;
    }
}