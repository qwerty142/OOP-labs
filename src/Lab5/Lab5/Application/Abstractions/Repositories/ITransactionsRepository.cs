namespace Lab5.Application.Abstractions.Repositories;

public interface ITransactionsRepository
{
    Task<bool> RegisterOperation(long accountId, string type, long amount);
}