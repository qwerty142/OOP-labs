using System.Diagnostics.CodeAnalysis;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Npgsql;

namespace Lab5.Infrustructure.Repositories;

public class TransactionsRepository : ITransactionsRepository
{
    private IPostgresConnectionProvider _connectionProvider;

    public TransactionsRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    [SuppressMessage("Category", "CA2007", Justification = "aboba")]
    [SuppressMessage("Category", "CA2000", Justification = "aba")]
    public async Task<bool> RegisterOperation(long accountId, string type, long amount)
    {
        string sql = """
                     insert into bank_account_operations
                     values(:accountId, :type, :amount)
                     """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("accountId", accountId)
            .AddParameter("type", type)
            .AddParameter("amount", amount);
        return await command.ExecuteNonQueryAsync() > 0;
    }
}