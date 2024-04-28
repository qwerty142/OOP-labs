using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;
using Spectre.Console;

namespace Lab5.Presentation.Scenarios.Scenarios.AddUser;

public class AddUserScenario : IScenario
{
    private IFacade _facade;

    public AddUserScenario(IFacade facade)
    {
        _facade = facade;
    }

    public string Name => "Add user";
    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task Run()
    {
        long id = AnsiConsole.Ask<long>("Enter Id:");
        string name = AnsiConsole.Ask<string>("Enter Name:");
        string password = AnsiConsole.Ask<string>("Enter your password:");
        string role = AnsiConsole.Ask<string>("Enter your role:");
        bool result = await _facade.AddUser(id, name, password, role);

        string message = result switch
        {
           true => "Successful creation",
           false => "User not found",
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}