using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Application.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Contracts.Facades;

public class FacadeAccessLevelProxy : IFacade
{
    private Facade _facade;

    public FacadeAccessLevelProxy(Facade facade, State state)
    {
        _facade = facade;
        State = state;
    }

    public State State { get; }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> CreateBankAccount(long userId, long accountId)
    {
        return await _facade.CreateBankAccount(userId, accountId);
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<long> CheckOutBalance(long accountId, long userId)
    {
        return await _facade.CheckOutBalance(accountId, userId);
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> TakeMoneyFromBankAccount(long accountId, long amount, long userId)
    {
        return await _facade.TakeMoneyFromBankAccount(accountId, amount, userId);
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> PutMoneyOnBankAccount(long accountId, int value, long userId)
    {
        return await _facade.PutMoneyOnBankAccount(accountId, value, userId);
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<IEnumerable<OperationsHistory>> CheckOutOperationsHistory(long accountId)
    {
        return await _facade.CheckOutOperationsHistory(accountId);
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> DeleteBankAccount(long accountId)
    {
        if (State.Role == UserRole.Admin)
        {
            return await _facade.DeleteBankAccount(accountId);
        }

        return false;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> DeleteUser(long userId)
    {
        if (State.Role == UserRole.User)
        {
            return await _facade.DeleteUser(userId);
        }

        return false;
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
        if (userRole == UserRole.Admin && State.Role != UserRole.Admin)
        {
            return false;
        }

        return await _facade.AddUser(userId, name, password, role);
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<User?> Login(long id, string password, string role)
    {
        return await _facade.Login(id, password, role);
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> ChangePassword(long id, string newPassword, string role)
    {
        return await _facade.ChangePassword(id, newPassword, role);
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> RegisterTransaction(long accountId, string type, long amount)
    {
        return await _facade.RegisterTransaction(accountId, type, amount);
    }
}