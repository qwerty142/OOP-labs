using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;

namespace Lab5.Presentation.Scenarios.Scenarios.ChangePassword;

public class ChangePasswordScenarioProvider : IScenarioProvider
{
    private readonly IFacade _facade;

    public ChangePasswordScenarioProvider(IFacade facade)
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

        scenario = new ChangePasswordScenario(_facade);
        return true;
    }
}