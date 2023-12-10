using Contracts.Users;
using Models.Operations;
using Spectre.Console;

namespace Console.Scenarios.CheckHistoryOperation;

public class CheckHistoryScenario : IScenario
{
    private readonly IUserService _accountService;

    public CheckHistoryScenario(IUserService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Check history operations";

    public void Run()
    {
        CheckHistoryOperationResult result = _accountService.CheckHistoryOperation();

        string message = result switch
        {
            CheckHistoryOperationResult.Success => $"Operation: ",
            CheckHistoryOperationResult.ExecuteError => "Execute Error",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);

        if (result is CheckHistoryOperationResult.Success success)
        {
            foreach (Operation operation in success.Operation)
            {
                System.Console.WriteLine(operation.TextOperation);
            }
        }

        System.Console.WriteLine("Press Enter");
        System.Console.ReadKey();
    }
}