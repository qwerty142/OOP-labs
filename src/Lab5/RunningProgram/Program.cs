// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Application.Extensions;
using Lab5.Infrustructure.Extensions;
using Lab5.Presentation.Scenarios;
using Lab5.Presentation.Scenarios.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

var collection = new ServiceCollection();

collection
    .AddApplication()
    .AddInfrastructureDataAccess(configuration =>
    {
        configuration.Host = "localhost";
        configuration.Port = 5432;
        configuration.Username = "postgres";
        configuration.Password = "postgres";
        configuration.Database = "postgres";
        configuration.SslMode = "Prefer";
    })
    .AddPresentationConsole();

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

scope.UseInfrastructureDataAccess();

ScenarioRunner scenarioRunner = scope.ServiceProvider
    .GetRequiredService<ScenarioRunner>();
while (true)
{
    await scenarioRunner.Run();
    AnsiConsole.Clear();
}
