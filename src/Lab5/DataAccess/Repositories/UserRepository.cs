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

    public async Task<Account?> FindAccountUserByAccountNumberAndPasswordAsync(long accountNumber, string password)
    {
        const string sql = """
        select account_id, account_number, account_password, balance
        from account
        where account_number = :accountNumber and account_password = :password;
        """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountNumber", accountNumber);
        command.AddParameter("password", password);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            return null;

        return new Account(
            Id: reader.GetInt64(0),
            AccountNumber: reader.GetInt64(1),
            Password: reader.GetString(2),
            Balance: reader.GetInt64(3));
    }

    public async Task<bool> ToUpBalance(long id, long amountMoney)
    {
        const string sqlUpDateBalance = """
        update account
        set balance = balance + :amountMoney
        where account_id = :id;
        """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using var command = new NpgsqlCommand(sqlUpDateBalance, connection);
        command.AddParameter("id", id);
        command.AddParameter("amountMoney", amountMoney);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        return await reader.ReadAsync().ConfigureAwait(false); // исправить (а то пишет, что операция не удалась)
    }
}