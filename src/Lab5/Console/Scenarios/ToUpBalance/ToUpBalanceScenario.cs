using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.ToUpBalance;

public class ToUpBalanceScenario : IScenario
{
    private readonly IUserService _accountService;

    public ToUpBalanceScenario(IUserService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "To up the balance";

    public void Run()
    {
        long toUpBalance = AnsiConsole.Ask<long>("Enter the amount of money");
        ToUpBalanceResult result = _accountService.ToUpAccountBalance(toUpBalance);
        string message = result switch
        {
            ToUpBalanceResult.Success success => $"Successful replenishment, current balance: {success.CurrentBalance}",
            ToUpBalanceResult.FailedTopUp => "An error occurred while performing the operation",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        System.Console.WriteLine("Press Enter");
        System.Console.ReadKey();
    }
}