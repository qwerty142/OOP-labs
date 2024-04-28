using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;

namespace Lab5.Presentation.Scenarios.Scenarios.PutMoneyOnBankAccount;

public class PutMoneyOnBankAccountScenarioProvider : IScenarioProvider
{
    private readonly IFacade _facade;

    public PutMoneyOnBankAccountScenarioProvider(IFacade facade)
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

        scenario = new PutMoneyOnBankAccountScenario(_facade);
        return true;
    }
}