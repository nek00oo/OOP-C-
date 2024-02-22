using Contracts.Admins;
using Spectre.Console;

namespace Console.Scenarios.CreateAccount;

public class CreateAccountScenario : IScenario
{
    private readonly IAdminService _adminService;

    public CreateAccountScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Create user account";

    public void Run()
    {
        long accountNumber = AnsiConsole.Ask<long>("Enter user account number:");
        string accountPassword = AnsiConsole.Ask<string>("Enter user account password:");

        CreateUserAccountResult result = _adminService.CreateUserAccount(accountNumber, accountPassword);

        string message = result switch
        {
            CreateUserAccountResult.Success => "Created",
            CreateUserAccountResult.UserAlreadyExists => "User account is already exist",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        System.Console.WriteLine("Press Enter");
        System.Console.ReadKey();
    }
}