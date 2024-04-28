using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Application.Users;

public static class UserHashing
{
    public static string UserSalt { get; set; } = "1z2x";
    public static string AdminSalt { get; set; } = "axfkgmwolfapkfwp";

    [SuppressMessage("Category", "CA1307", Justification = "aboba")]
    public static string HashUser(string password, UserRole role)
    {
        string salt = role switch
        {
            UserRole.Admin => AdminSalt,
            UserRole.User => UserSalt,
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, null),
        };
        byte[] source = Encoding.UTF8.GetBytes(password + salt);
        byte[] hash = SHA256.HashData(source);
        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }
}