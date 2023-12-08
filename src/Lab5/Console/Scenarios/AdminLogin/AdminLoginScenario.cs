using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.AdminLogin;

public class AdminLoginScenario : IScenario
{
    private readonly IUserService _userService; // поменять (AdminService)

    public AdminLoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Admin Login";

    public void Run()
    {
        long username = AnsiConsole.Ask<long>("Enter your username");

        LoginResult result = _userService.Login(username, "dsf");

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}