using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Application.Users;
using Lab5.Application.Models;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Contracts.Facades;

public class Facade : IFacade
{
    private IBankAccountRepository _repository;
    private IUserRepository _userRepository;
    private ITransactionsRepository _transactionsRepository;

    public Facade(IBankAccountRepository repository, IUserRepository userRepository, State state, ITransactionsRepository transactionsRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
        State = state;
        _transactionsRepository = transactionsRepository;
    }

    public State State { get; }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> CreateBankAccount(long userId, long accountId)
    {
        if (userId != State.User?.Id)
        {
            return false;
        }

        IEnumerable<BankAccount> task = await _repository.GetAllAccounts(userId);

        if (task.Any(s => s.Id == accountId))
        {
            return false;
        }

        bool resTask = await _repository.Add(userId, accountId);
        return resTask;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<long> CheckOutBalance(long accountId, long userId)
    {
        if (userId != State.User?.Id)
        {
            return -1;
        }

        IEnumerable<BankAccount> task = await _repository.GetAllAccounts(userId);
        BankAccount? result = task.FirstOrDefault(s => s.Id == accountId);
        if (result is null)
        {
            return -1;
        }

        return result.Value;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> TakeMoneyFromBankAccount(long accountId, long amount, long userId)
    {
        IEnumerable<BankAccount> task = await _repository.GetAllAccounts(userId);
        bool regTask = await _transactionsRepository.RegisterOperation(accountId, "out", amount);

        BankAccount? result = task.FirstOrDefault(s => s.Id == accountId);
        if (result is null)
        {
            return false;
        }

        if (result.Value < amount)
        {
            return false;
        }

        bool resTask = await _repository.Update(accountId, amount, "Removal");

        return resTask && regTask;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> PutMoneyOnBankAccount(long accountId, int value, long userId)
    {
        IEnumerable<BankAccount> task = await _repository.GetAllAccounts(userId);

        bool regTask = await _transactionsRepository.RegisterOperation(accountId, "in", value);

        BankAccount? result = task.FirstOrDefault(s => s.Id == accountId);
        if (result is null)
        {
           return false;
        }

        bool resTask = await _repository.Update(accountId, value, "Put");
        return resTask && regTask;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<IEnumerable<OperationsHistory>> CheckOutOperationsHistory(long accountId)
    {
        IEnumerable<OperationsHistory> task = await _repository.GetAllOperations(accountId);

        return task;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> DeleteBankAccount(long accountId)
    {
        bool task = await _repository.Delete(accountId);

        return task;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> DeleteUser(long userId)
    {
        bool task = await _userRepository.DeleteUser(userId);

        return task;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> AddUser(long userId, string name, string password, string role)
    {
        UserRole userRole = role switch
        {
            "admin" => UserRole.Admin,
            "user" => UserRole.User,
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, null),
        };
        bool task = await _userRepository.AddUser(password, name, userRole);

        return task;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<User?> Login(long id, string password, string role)
    {
        User? task = await _userRepository.Login(id, password, role);

        return task;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> ChangePassword(long id, string newPassword, string role)
    {
        if (State.User == null || State.User.Id != id)
        {
            return false;
        }

        bool task = await _userRepository.UpdateUser(id, newPassword, role);

        return task;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> RegisterTransaction(long accountId, string type, long amount)
    {
        bool task = await _transactionsRepository.RegisterOperation(accountId, type, amount);

        return task;
    }
}