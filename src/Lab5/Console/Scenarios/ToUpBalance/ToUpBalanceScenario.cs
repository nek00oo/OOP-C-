using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.ToUpBalance;

public class ToUpBalanceScenario : IScenario
{
    private readonly IUserService _accountService;
    private readonly long _accountId;

    public ToUpBalanceScenario(IUserService accountService, long accountId)
    {
        _accountService = accountService;
        _accountId = accountId;
    }

    public string Name => "To up the balance";

    public void Run()
    {
        long toUpBalance = AnsiConsole.Ask<long>("Enter the amount of money");
        ToUpBalanceResult result = _accountService.ToUpAccountBalance(_accountId, toUpBalance);
        string message = result switch
        {
            ToUpBalanceResult.Success => "Successful replenishment",
            ToUpBalanceResult.FailedTopUp => "An error occurred while performing the operation",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}