using Console.Scenarios.AdminLogin;
using Console.Scenarios.CheckBalance;
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

        return collection;
    }
}