using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;
using Spectre.Console;

namespace Lab5.Presentation.Scenarios.Scenarios.CheckBalance;

public class CheckBalanceScenario : IScenario
{
    private IFacade _facade;

    public CheckBalanceScenario(IFacade facade)
    {
        _facade = facade;
    }

    public string Name => "Check Balance";

    [SuppressMessage("Category", "CA1305", Justification = "aboba")]
    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task Run()
    {
        if (_facade.State.User is null)
        {
            AnsiConsole.Ask<string>("First, enter your account");
        }
        else
        {
            long accountId = AnsiConsole.Ask<long>("Enter your account id:");

            long result = await _facade.CheckOutBalance(accountId, _facade.State.User.Id);

            string message = result switch
            {
                -1 => "Error while trying",
                _ => "Current amount is " + result.ToString(),
            };

            AnsiConsole.WriteLine(message);
            AnsiConsole.Ask<string>("Ok");
        }
    }
}