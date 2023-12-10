using Abstractions.Repositories;
using Contracts.Users;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Accounts;
using Models.Operations;
using Npgsql;

namespace DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<UserAccount?> FindAccountUserByAccountNumberAndPasswordAsync(long accountNumber, string password)
    {
        const string sql = """
        select account_id, balance
        from user_account
        where account_number = :accountNumber and account_password = :password;
        """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountNumber", accountNumber);
        command.AddParameter("password", password);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            return null;

        return new UserAccount(Id: reader.GetInt64(0), UserRole.User, reader.GetInt64(1));
    }

    public async Task<long?> ToUpBalanceAsync(long id, long amountMoney)
    {
        await AddHistoryOperation(id, "to up balance");
        const string sqlUpDateBalance = """
        update user_account
        set balance = balance + :amountMoney
        where account_id = :id;
        """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sqlUpDateBalance, connection);
        command.AddParameter("id", id);
        command.AddParameter("amountMoney", amountMoney);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);

        long? currentMoney = await CheckBalance(id).ConfigureAwait(false);
        if (currentMoney is null)
            return null;
        return currentMoney.Value;
    }

    public async Task<MakeWithdrawalResult?> MakeWithdrawalAsync(long id, long amountMoney)
    {
        long? currentMoney = await CheckBalance(id).ConfigureAwait(false);
        if (currentMoney is null)
            return null;
        if (currentMoney.Value < amountMoney)
            return new MakeWithdrawalResult.NotEnoughMoneyInAccount();

        await AddHistoryOperation(id, "make a withdrawal");
        const string sqlMakeWithdrawal = """
        update user_account
        set balance = balance - :amountMoney
        where account_id = :id;
        """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sqlMakeWithdrawal, connection);
        command.AddParameter("id", id);
        command.AddParameter("amountMoney", amountMoney);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);

        currentMoney = await CheckBalance(id).ConfigureAwait(false);
        if (currentMoney is null)
            return null;
        return new MakeWithdrawalResult.Success(currentMoney.Value);
    }

    public async Task<long?> CheckBalance(long id)
    {
        await AddHistoryOperation(id, "check balance");
        const string sqlCheckBalance = """
        select balance
        from user_account
        where account_id = :id;
        """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sqlCheckBalance, connection);
        command.AddParameter("id", id);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            return null;
        return reader.GetInt64(0);
    }

    public async IAsyncEnumerable<Operation> CheckHistoryOperation(long accountId)
    {
        await AddHistoryOperation(accountId, "check history operations");
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

    private async Task<Operation> AddHistoryOperation(long accountId, string textOperation)
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