using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Operations;
using Npgsql;

namespace DataAccess.Repositories;

public class HistoryOperationRepository : IHistoryOperationRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public HistoryOperationRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async IAsyncEnumerable<Operation> CheckHistoryOperation(long accountId)
    {
        const string sqlCheckHistoryOperation = """
                                                select operation
                                                from history_operations
                                                where account_id = :accountId;
                                                """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sqlCheckHistoryOperation, connection);
        command.AddParameter("accountId", accountId);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            yield return new Operation(reader.GetString(0));
        }
    }

    public async Task<Operation> AddHistoryOperation(long accountId, string textOperation)
    {
        const string sqlAddHistoryOperation = """
                                              insert into history_operations(account_id, operation)
                                              values (:accountId, :textOperation);
                                              """;
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sqlAddHistoryOperation, connection);
        command.AddParameter("accountId", accountId);
        command.AddParameter("textOperation", textOperation);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);

        return new Operation(textOperation);
    }
}