using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.CheckBalance;

public class CheckBalanceScenario : IScenario
{
    private readonly IUserService _accountService;
    private readonly long _accountId;

    public CheckBalanceScenario(IUserService accountService, long accountId)
    {
        _accountService = accountService;
        _accountId = accountId;
    }

    public string Name => "Check balance";

    public void Run()
    {
        CheckBalanceResult result = _accountService.CheckBalance(_accountId);

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