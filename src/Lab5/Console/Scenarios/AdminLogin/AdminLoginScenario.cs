using Contracts.Admins;
using Spectre.Console;

namespace Console.Scenarios.AdminLogin;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLoginScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Admin Login";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter admin password");

        AccessCheckResult result = _adminService.Login(password);

        string message = result switch
        {
            AccessCheckResult.Success => "Successful",
            AccessCheckResult.IncorrectPassword => "The password is incorrect",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        if (result is AccessCheckResult.IncorrectPassword)
            Environment.Exit(0);

        AnsiConsole.WriteLine(message);
        System.Console.WriteLine("Press Enter");
        System.Console.ReadKey();
    }
}