using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;

namespace Lab5.Presentation.Scenarios.Scenarios.CreateBankAccount;

public class CreateBankAccountScenarioProvider : IScenarioProvider
{
    private readonly IFacade _facade;

    public CreateBankAccountScenarioProvider(IFacade facade)
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

        scenario = new CreateBankAccountScenario(_facade);
        return true;
    }
}