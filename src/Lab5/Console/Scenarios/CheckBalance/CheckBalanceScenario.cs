using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.CheckBalance;

public class CheckBalanceScenario : IScenario
{
    private readonly IUserService _accountService;

    public CheckBalanceScenario(IUserService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Check balance";

    public void Run()
    {
        CheckBalanceResult result = _accountService.CheckBalance();

        string message = result switch
        {
            CheckBalanceResult.Success success => $"Balance: {success.Balance}",
            CheckBalanceResult.NotFoundAccount => "Account not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        System.Console.WriteLine("Press Enter");
        System.Console.ReadKey();
    }
}