using Lab5.Application.Models;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IBankAccountRepository
{
    Task<IEnumerable<BankAccount>> GetAllAccounts(long userId);

    Task<bool> Update(long accountId, long amount, string operationType);

    Task<bool> Add(long userId, long accountId);

    Task<bool> Delete(long accountId);

    Task<IEnumerable<OperationsHistory>> GetAllOperations(long accountId);
}