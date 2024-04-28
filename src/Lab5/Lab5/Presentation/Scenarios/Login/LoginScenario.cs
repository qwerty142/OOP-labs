using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;
using Spectre.Console;

namespace Lab5.Presentation.Scenarios.Login;

public class LoginScenario : IScenario
{
    private IFacade _facade;

    public LoginScenario(IFacade facade)
    {
        _facade = facade;
    }

    public string Name => "Login";

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task Run()
    {
        long id = AnsiConsole.Ask<long>("Enter your id");
        string password = AnsiConsole.Ask<string>("Enter password:");
        string userRole = AnsiConsole.Ask<string>("Enter your role:");
        User? result = await _facade.Login(id, password, userRole);

        _facade.State.User = result;
        _facade.State.Role = result?.Role;
        LoginResult loginResult = result is null ? LoginResult.NotFound : LoginResult.Success;

        string message = loginResult switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}