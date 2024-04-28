using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;

namespace Lab5.Presentation.Scenarios.Scenarios.CheckOutOperationsHistory;

public class CheckOutOperationsHistoryScenarioProvider : IScenarioProvider
{
    private readonly IFacade _facade;

    public CheckOutOperationsHistoryScenarioProvider(IFacade facade)
    {
        _facade = facade;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_facade.State.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new CheckOutOperationsHistoryScenario(_facade);
        return true;
    }
}