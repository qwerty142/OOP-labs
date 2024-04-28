using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;

namespace Lab5.Presentation.Scenarios.Scenarios.TakeMoneyFromBankAccount;

public class TakeMoneyFromBankAccountScenarioProvider : IScenarioProvider
{
    private readonly IFacade _facade;

    public TakeMoneyFromBankAccountScenarioProvider(IFacade facade)
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

        scenario = new TakeMoneyFromBankAccountScenario(_facade);
        return true;
    }
}