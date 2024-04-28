using Lab5.Application.Application.Accounts;
using Lab5.Application.Application.Users;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Facades;
using Lab5.Application.Contracts.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IBankAccountServices, BankAccountService>();

        collection.AddScoped<Facade, Facade>();
        collection.AddScoped<IFacade, FacadeAccessLevelProxy>();

        collection.AddScoped<IState, State>();

        collection.AddScoped<State>();
        collection.AddScoped<IState>(
            p => p.GetRequiredService<State>());

        return collection;
    }
}