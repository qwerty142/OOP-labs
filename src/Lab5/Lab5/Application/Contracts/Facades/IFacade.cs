using Lab5.Application.Application.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Contracts.Facades;

public interface IFacade
{
    public State State { get; }
    Task<bool> CreateBankAccount(long userId, long accountId);

    Task<long> CheckOutBalance(long accountId, long userId);

    Task<bool> TakeMoneyFromBankAccount(long accountId, long amount, long userId);

    Task<bool> PutMoneyOnBankAccount(long accountId, int value, long userId);

    Task<IEnumerable<OperationsHistory>> CheckOutOperationsHistory(long accountId);

    Task<bool> DeleteBankAccount(long accountId);

    Task<bool> DeleteUser(long userId);

    Task<bool> AddUser(long userId, string name, string password, string role);
    Task<User?> Login(long id, string password, string role);
    Task<bool> ChangePassword(long id, string newPassword, string role);
    Task<bool> RegisterTransaction(long accountId, string type, long amount);
}