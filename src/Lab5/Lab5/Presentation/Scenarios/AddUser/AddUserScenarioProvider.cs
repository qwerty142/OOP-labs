using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;

namespace Lab5.Presentation.Scenarios.Scenarios.AddUser;

public class AddUserScenarioProvider : IScenarioProvider
{
    private readonly IFacade _facade;

    public AddUserScenarioProvider(IFacade facade)
    {
        _facade = facade;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_facade.State.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AddUserScenario(_facade);
        return true;
    }
}