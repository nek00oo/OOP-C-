using Application.Admins;
using Application.Users;
using Contracts.Admins;
using Contracts.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();

        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());

        collection.AddScoped<IAdminService, AdminService>();
        collection.AddScoped<CurrentAdminManager>();
        collection.AddScoped<ICurrentAdminService>(p => p.GetRequiredService<CurrentAdminManager>());

        return collection;
    }
}