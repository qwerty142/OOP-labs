using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User?> FindUserById(long id);

    Task<bool> UpdateUser(long id, string newPassword, string role);

    Task<bool> DeleteUser(long id);

    Task<bool> AddUser(string password, string name, UserRole role);

    Task<User?> Login(long id, string password, string role);
}