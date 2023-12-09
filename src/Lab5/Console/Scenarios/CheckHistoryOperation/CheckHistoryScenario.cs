using Contracts.Users;
using Models.Operations;
using Spectre.Console;

namespace Console.Scenarios.CheckHistoryOperation;

public class CheckHistoryScenario : IScenario
{
    private readonly IUserService _accountService;
    private readonly long _accountId;

    public CheckHistoryScenario(IUserService accountService, long accountId)
    {
        _accountService = accountService;
        _accountId = accountId;
    }

    public string Name => "Check history operations";

    public void Run()
    {
        CheckHistoryOperationResult result = _accountService.CheckHistoryOperation(_accountId);

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