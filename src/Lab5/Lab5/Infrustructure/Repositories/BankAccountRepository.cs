using System.Diagnostics.CodeAnalysis;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models;
using Lab5.Application.Models.Users;
using Npgsql;

namespace Lab5.Infrustructure.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private IPostgresConnectionProvider _connectionProvider;

    public BankAccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    [SuppressMessage("Category", "CA2000", Justification = "aba")]
    public async Task<IEnumerable<BankAccount>> GetAllAccounts(long userId)
    {
        const string sql = """
                           select id, account_id, value
                           from bank_accounts
                           where id = :userId
                           """;
        NpgsqlConnection connection = await _connectionProvider
                .GetConnectionAsync(CancellationToken.None);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("userId", userId);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        var accounts = new List<BankAccount>();
        while (await reader.ReadAsync())
        {
            accounts.Add(new BankAccount(
                reader.GetInt64(1),
                reader.GetInt32(2)));
        }

        return accounts;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    [SuppressMessage("Category", "CA2000", Justification = "aba")]
    public async Task<bool> Update(long accountId, long amount, string operationType)
    {
        string sql;
        if (operationType == BankAccountOperations.Put.ToString())
        {
            sql = """
                  update bank_accounts
                  set value = value + :amount
                  where account_id = :accountId
                  """;
        }
        else if (operationType == BankAccountOperations.Removal.ToString())
        {
            sql = """
                  update bank_accounts
                  set value = value - :amount
                  where account_id = :accountId
                  """;
        }
        else
        {
            throw new ArgumentException("no such operation");
        }

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("amount", amount)
            .AddParameter("accountId", accountId);
        return await command.ExecuteNonQueryAsync() > 0;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    [SuppressMessage("Category", "CA2000", Justification = "aba")]
    public async Task<bool> Add(long userId, long accountId)
    {
        const string sql = """
                           insert into bank_accounts
                           VALUES(:userId, :accountId, 0)
                           """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("userId", userId)
            .AddParameter("accountId", accountId);
        return await command.ExecuteNonQueryAsync() > 0;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    [SuppressMessage("Category", "CA2000", Justification = "aba")]
    public async Task<bool> Delete(long accountId)
    {
        const string sql = """
                           delete from bank_accounts
                           where account_id = :accountId
                           """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("accountId", accountId);
        return await command.ExecuteNonQueryAsync() > 0;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    [SuppressMessage("Category", "CA2000", Justification = "aba")]
    public async Task<IEnumerable<OperationsHistory>> GetAllOperations(long accountId)
    {
        const string sql = """
                           select bank_account_id, type, amount
                           from bank_account_operations
                           where bank_account_id = :accountId
                           """;
        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("accountId", accountId);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        var accounts = new List<OperationsHistory>();
        while (await reader.ReadAsync())
        {
            accounts.Add(new OperationsHistory(
                reader.GetInt64(0),
                reader.GetString(1),
                reader.GetInt64(2)));
        }

        return accounts;
    }
}