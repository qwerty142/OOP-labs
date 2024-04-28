using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models;

namespace Lab5.Application.Application.Accounts;

public class BankAccountService : IBankAccountServices
{
    private readonly IBankAccountRepository _accountRepository;

    public BankAccountService(IBankAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public Task<IEnumerable<BankAccount>> GetAllAccounts(long userId)
    {
        return _accountRepository.GetAllAccounts(userId);
    }
}