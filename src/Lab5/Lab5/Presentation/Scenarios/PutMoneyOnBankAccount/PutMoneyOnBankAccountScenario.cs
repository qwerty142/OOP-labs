using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;
using Spectre.Console;

namespace Lab5.Presentation.Scenarios.Scenarios.PutMoneyOnBankAccount;

public class PutMoneyOnBankAccountScenario : IScenario
{
    private IFacade _facade;

    public PutMoneyOnBankAccountScenario(IFacade facade)
    {
        _facade = facade;
    }

    public string Name => "Put money";

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
            long accountId = AnsiConsole.Ask<long>("Enter account id:");
            int value = AnsiConsole.Ask<int>("Enter value:");
            bool result = await _facade.PutMoneyOnBankAccount(accountId, value, _facade.State.User.Id);

            string message = result switch
            {
                false => "Error while trying to put money",
                true => "Success puted " + value.ToString(),
            };

            AnsiConsole.WriteLine(message);
            AnsiConsole.Ask<string>("Ok");
        }
    }
}