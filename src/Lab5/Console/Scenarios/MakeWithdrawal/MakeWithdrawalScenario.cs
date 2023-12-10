using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.MakeWithdrawal;

public class MakeWithdrawalScenario : IScenario
{
    private readonly IUserService _accountService;

    public MakeWithdrawalScenario(IUserService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Make a withdrawal";

    public void Run()
    {
        long toUpBalance = AnsiConsole.Ask<long>("Enter the amount of money");
        MakeWithdrawalResult result = _accountService.MakeWithdrawal(toUpBalance);

        string message = result switch
        {
            MakeWithdrawalResult.Success success => $"Successful cash withdrawal, current balance: {success.CurrentBalance}",
            MakeWithdrawalResult.NotEnoughMoneyInAccount => "Insufficient money in the bank",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        System.Console.WriteLine("Press Enter");
        System.Console.ReadKey();
    }
}