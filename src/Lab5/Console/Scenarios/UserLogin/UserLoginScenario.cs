using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.UserLogin;

public class UserLoginScenario : IScenario
{
    private readonly IUserService _userService;

    public UserLoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "User Login";

    public void Run()
    {
        long accountNumber = AnsiConsole.Ask<long>("Enter your account number");
        string password = AnsiConsole.Ask<string>("Enter the password for your account");

        LoginResult result = _userService.Login(accountNumber, password);

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