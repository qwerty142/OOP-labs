using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;
using Spectre.Console;

namespace Lab5.Presentation.Scenarios.Scenarios.ChangePassword;

public class ChangePasswordScenario : IScenario
{
    private IFacade _facade;

    public ChangePasswordScenario(IFacade facade)
    {
        _facade = facade;
    }

    public string Name => "Change password";

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task Run()
    {
        long id = AnsiConsole.Ask<long>("Enter login:");
        string newPassword = AnsiConsole.Ask<string>("Enter new password:");
        string role = AnsiConsole.Ask<string>("Enter your role:");

        bool result = await _facade.ChangePassword(id, newPassword, role);

        string message = result switch
        {
            true => "successfully changed",
            false => "Error while trying to change password",
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}