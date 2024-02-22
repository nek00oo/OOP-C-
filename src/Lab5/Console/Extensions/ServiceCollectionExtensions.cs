using Console.Scenarios.AdminLogin;
using Console.Scenarios.ChangingPassword;
using Console.Scenarios.CheckBalance;
using Console.Scenarios.CheckHistoryOperation;
using Console.Scenarios.CreateAccount;
using Console.Scenarios.MakeWithdrawal;
using Console.Scenarios.ToUpBalance;
using Console.Scenarios.UserLogin;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, UserLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLoginProvider>();
        collection.AddScoped<IScenarioProvider, ToUpBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, MakeWithdrawalScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckHistoryScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ChangingPasswordScenarioProvider>();

        return collection;
    }
}