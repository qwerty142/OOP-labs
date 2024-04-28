using Lab5.Application.Contracts.Users;
using Lab5.Application.Models;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Application.Users;

public class State : IState
{
    public User? User { get; set; }

    public BankAccount? BankAccount { get; set; }

    public UserRole? Role { get; set; }
}