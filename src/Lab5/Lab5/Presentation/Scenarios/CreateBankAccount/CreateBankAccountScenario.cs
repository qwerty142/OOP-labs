using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;
using Spectre.Console;

namespace Lab5.Presentation.Scenarios.Scenarios.CreateBankAccount;

public class CreateBankAccountScenario : IScenario
{
    private IFacade _facade;

    public CreateBankAccountScenario(IFacade facade)
    {
        _facade = facade;
    }

    public string Name => "Create Bank Account";

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task Run()
    {
        if (_facade.State.User is null)
        {
            AnsiConsole.Ask<string>("First, enter in your account");
        }
        else
        {
            long accountId = AnsiConsole.Ask<long>("Enter your account");
            bool result = await _facade.CreateBankAccount(_facade.State.User.Id, accountId);

            string message = result switch
            {
                true => "Successful creation",
                false => "Error while creating",
            };

            AnsiConsole.WriteLine(message);
            AnsiConsole.Ask<string>("Ok");
        }
    }
}