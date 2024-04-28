namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    Task<LoginResult> Login(long id);
}