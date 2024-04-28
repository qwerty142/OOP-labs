using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Facades;
using Lab5.Application.Models.Users;

namespace Lab5.Presentation.Scenarios.Scenarios.DeleteBankAccount;

public class DeleteBankAccountScenarioProvider : IScenarioProvider
{
    private readonly IFacade _facade;

    public DeleteBankAccountScenarioProvider(IFacade facade)
    {
        _facade = facade;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_facade.State.User is null || _facade.State.User.Role != UserRole.Admin)
        {
            scenario = null;
            return false;
        }

        scenario = new DeleteBankAccountScenario(_facade);
        return true;
    }
}