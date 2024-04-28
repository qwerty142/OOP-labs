using Lab5.Presentation.Scenarios.Login;
using Lab5.Presentation.Scenarios.Scenarios.AddUser;
using Lab5.Presentation.Scenarios.Scenarios.ChangePassword;
using Lab5.Presentation.Scenarios.Scenarios.CheckBalance;
using Lab5.Presentation.Scenarios.Scenarios.CheckOutOperationsHistory;
using Lab5.Presentation.Scenarios.Scenarios.CreateBankAccount;
using Lab5.Presentation.Scenarios.Scenarios.DeleteBankAccount;
using Lab5.Presentation.Scenarios.Scenarios.DeleteUser;
using Lab5.Presentation.Scenarios.Scenarios.PutMoneyOnBankAccount;
using Lab5.Presentation.Scenarios.Scenarios.TakeMoneyFromBankAccount;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Scenarios.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateBankAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ChangePasswordScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckOutOperationsHistoryScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DeleteBankAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DeleteUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, PutMoneyOnBankAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, TakeMoneyFromBankAccountScenarioProvider>();

        return collection;
    }
}