using System.Diagnostics.CodeAnalysis;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Application.Users;
using Lab5.Application.Models.Users;
using Npgsql;

namespace Lab5.Infrustructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    [SuppressMessage("Category", "CA2000", Justification = "aba")]
    public async Task<User?> FindUserById(long id)
    {
        const string sql = """
                           select id, name, salt, password_hash, role
                           from users
                           where id = :id
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("id", id);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        User? user = null;
        while (await reader.ReadAsync())
        {
            UserRole role = reader.GetString(4) switch
            {
                "user" => UserRole.User,
                "admin" => UserRole.Admin,
                _ => throw new ArgumentOutOfRangeException(nameof(id)),
            };
            user = new User(
                reader.GetInt64(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                role);
        }

        return user;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    [SuppressMessage("Category", "CA2000", Justification = "aba")]
    public async Task<bool> UpdateUser(long id, string newPassword, string role)
    {
        UserRole userRole = role switch
        {
            "user" => UserRole.User,
            "admin" => UserRole.Admin,
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, null),
        };
        string hashedPassword = UserHashing.HashUser(newPassword, userRole);
        const string sql = """
                           update users
                           set password_hash = :hashedPassword
                           where id = :id
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("hashedPassword", hashedPassword)
            .AddParameter("id", id);
        return await command.ExecuteNonQueryAsync() > 0;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    [SuppressMessage("Category", "CA2000", Justification = "aba")]
    public async Task<bool> DeleteUser(long id)
    {
        const string sql = """
                           delete from users
                           where id = :id
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("id", id);
        return await command.ExecuteNonQueryAsync() > 0;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<bool> AddUser(string password, string name, UserRole role)
    {
        string hashedPassword = UserHashing.HashUser(password, role);
        string salt = role switch
        {
            UserRole.Admin => UserHashing.AdminSalt,
            UserRole.User => UserHashing.UserSalt,
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, null),
        };
        string stringRole = role.ToString();

        const string sql = """
                           insert into users
                           values(DEFAULT, :name, :salt, :hashedPassword, :stringRole)
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using var command = new NpgsqlCommand(sql, connection);
        command
            .AddParameter("name", name)
            .AddParameter("salt", salt)
            .AddParameter("hashedPassword", hashedPassword)
            .AddParameter("stringRole", stringRole);
        return await command.ExecuteNonQueryAsync() > 0;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    public async Task<User?> Login(long id, string password, string role)
    {
        UserRole userRole = role switch
        {
            "user" => UserRole.User,
            "admin" => UserRole.Admin,
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, null),
        };
        string hashedPassword = UserHashing.HashUser(password, userRole);
        const string sql = """
                           select id, name, salt, password_hash, role
                           from users
                           where id = :id and password_hash = :hashedPassword
                           """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("id", id)
                .AddParameter("hashedPassword", hashedPassword);
            await using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
            {
                User? user = null;
                while (await reader.ReadAsync())
                {
                    user = new User(
                        reader.GetInt64(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        userRole);
                }

                return user;
            }
        }
    }
}