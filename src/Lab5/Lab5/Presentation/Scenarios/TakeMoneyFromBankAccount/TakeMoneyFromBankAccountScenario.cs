using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;
using Spectre.Console;

namespace Lab5.Presentation.Scenarios.Scenarios.TakeMoneyFromBankAccount;

public class TakeMoneyFromBankAccountScenario : IScenario
{
    private IFacade _facade;

    public TakeMoneyFromBankAccountScenario(IFacade facade)
    {
        _facade = facade;
    }

    public string Name => "Take money";

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
            long amount = AnsiConsole.Ask<long>("Enter amount:");

            bool result = await _facade
                .TakeMoneyFromBankAccount(accountId, amount, _facade.State.User.Id);
            string message = result switch
            {
                false => "Error while trying to take money",
                true => "Success took " + amount.ToString(),
            };

            AnsiConsole.WriteLine(message);
            AnsiConsole.Ask<string>("Ok");
        }
    }
}