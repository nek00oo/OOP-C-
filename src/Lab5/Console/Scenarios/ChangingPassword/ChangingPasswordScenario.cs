using Contracts.Admins;
using Spectre.Console;

namespace Console.Scenarios.ChangingPassword;

public class ChangingPasswordScenario : IScenario
{
    private readonly IAdminService _adminService;
    private readonly long _currentId;

    public ChangingPasswordScenario(IAdminService adminService, long id)
    {
        _adminService = adminService;
        _currentId = id;
    }

    public string Name => "Change the password";

    public void Run()
    {
        string accountPassword = AnsiConsole.Ask<string>("Enter new account password:");

        ChangePasswordResult result = _adminService.ChangePassword(accountPassword, _currentId);

        string message = result switch
        {
            ChangePasswordResult.Success => "Success",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        System.Console.WriteLine("Press Enter");
        System.Console.ReadKey();
    }
}