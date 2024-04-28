using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;
using Spectre.Console;

namespace Lab5.Presentation.Scenarios.Scenarios.DeleteUser;

public class DeleteUserScenario : IScenario
{
    private IFacade _facade;

    public DeleteUserScenario(IFacade facade)
    {
        _facade = facade;
    }

    public string Name => "Delete user";

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task Run()
    {
        if (_facade.State.User is null)
        {
            AnsiConsole.Ask<string>("First, enter your account");
        }
        else
        {
            long userId = AnsiConsole.Ask<long>("Enter user id:");
            bool result = await _facade.DeleteUser(userId);

            string message = result switch
            {
                true => "successfully deleted",
                false => "Error while trying to delete",
            };

            AnsiConsole.WriteLine(message);
            AnsiConsole.Ask<string>("Ok");
        }
    }
}