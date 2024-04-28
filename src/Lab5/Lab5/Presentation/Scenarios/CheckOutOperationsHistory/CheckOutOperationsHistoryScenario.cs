using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;
using Lab5.Application.Models.Users;
using Spectre.Console;

namespace Lab5.Presentation.Scenarios.Scenarios.CheckOutOperationsHistory;

public class CheckOutOperationsHistoryScenario : IScenario
{
    private IFacade _facade;

    public CheckOutOperationsHistoryScenario(IFacade facade)
    {
        _facade = facade;
    }

    public string Name => "Check operations";

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
            long accountId = AnsiConsole.Ask<long>("Enter your account:");
            IEnumerable<OperationsHistory> result = await _facade.CheckOutOperationsHistory(accountId);
            var table = new Table();
            table.AddColumn(new TableColumn("id")).Centered();
            table.AddColumn(new TableColumn("type")).Centered();
            table.AddColumn(new TableColumn("amount")).Centered();

            foreach (OperationsHistory val in result)
            {
                table.AddRow(
                    val.Id.ToString(),
                    val.Type.ToString(),
                    val.Amount.ToString());
            }

            AnsiConsole.Write(table);
            AnsiConsole.Ask<string>("Ok");
        }
    }
}