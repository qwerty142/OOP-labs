using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly State _userManager;

    public UserService(IUserRepository userRepository, State userManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<LoginResult> Login(long id)
    {
        User? result = await _userRepository.FindUserById(id);

        if (result is null)
        {
            return LoginResult.NotFound;
        }

        _userManager.User = result;
        return LoginResult.Success;
    }
}