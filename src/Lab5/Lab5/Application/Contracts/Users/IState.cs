using Lab5.Application.Models;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Contracts.Users;

public interface IState
{
    User? User { get; }

    BankAccount? BankAccount { get; set; }

    UserRole? Role { get; set; }
}