using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;
using Spectre.Console;

namespace Lab5.Presentation.Scenarios.Scenarios.DeleteBankAccount;

public class DeleteBankAccountScenario : IScenario
{
    private IFacade _facade;

    public DeleteBankAccountScenario(IFacade facade)
    {
        _facade = facade;
    }

    public string Name => "Delete bank account";

    [SuppressMessage("Category", "CA1305", Justification = "aboba")]
    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task Run()
    {
        long accountId = AnsiConsole.Ask<long>("Enter account id:");
        bool result = await _facade.DeleteBankAccount(accountId);

        string message = result switch
        {
            false => "Error while trying to delete",
            true => "successfully deleted account with id" + accountId.ToString(),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}