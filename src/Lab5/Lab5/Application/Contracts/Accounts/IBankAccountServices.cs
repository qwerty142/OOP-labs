using Lab5.Application.Models;

namespace Lab5.Application.Contracts.Accounts;

public interface IBankAccountServices
{
    Task<IEnumerable<BankAccount>> GetAllAccounts(long userId);
}