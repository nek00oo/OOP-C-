using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Accounts;
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

        return new UserAccount(
            Id: reader.GetInt64(0),
            UserRole.User,
            reader.GetInt64(1));
    }

    public async Task ToUpBalanceAsync(long id, long amountMoney)
    {
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
    }

    public async Task MakeWithdrawalAsync(long id, long amountMoney)
    {
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
    }

    public async Task<long?> CheckBalance(long id)
    {
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
}