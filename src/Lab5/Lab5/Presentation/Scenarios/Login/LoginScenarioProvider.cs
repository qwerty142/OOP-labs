using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Scenarios.Login;

public class LoginScenarioProvider : IScenarioProvider
{
    private readonly IFacade _service;
    private readonly IState _currentUser;

    public LoginScenarioProvider(
        IFacade service,
        IState currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginScenario(_service);
        return true;
    }
}