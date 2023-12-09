using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Accounts;
using Npgsql;

namespace DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<UserAccount?> FindAdminByPasswordAsync(string password)
    {
        const string sql = """
        select admin_id, admin_password
        from admins
        where admin_password = :password;
        """;
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("password", password);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            return null;

        return new UserAccount(Id: reader.GetInt64(0), UserRole.Admin);
    }

    public async Task<bool?> CreateUserAccount(long accountNumber, string accountPassword)
    {
        const string sqlCheckAccountExistence = """
                                                select count(*)
                                                from user_account
                                                where account_number = :accountNumber
                                                """;
        const string sqlCreateUserAccount = """
                                            insert into user_account(account_number, account_password, balance)
                                            values (:accountNumber, :accountPassword, 0)
                                            """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using (var checkCommand = new NpgsqlCommand(sqlCheckAccountExistence, connection))
        {
            checkCommand.AddParameter("accountNumber", accountNumber);
            using NpgsqlDataReader reader = await checkCommand.ExecuteReaderAsync().ConfigureAwait(false);

            if (await reader.ReadAsync().ConfigureAwait(false) is false)
                return null;

            if (reader.GetInt64(0) > 0)
                return false;
        }

        await using (var createCommand = new NpgsqlCommand(sqlCreateUserAccount, connection))
        {
            createCommand.AddParameter("accountNumber", accountNumber);
            createCommand.AddParameter("accountPassword", accountPassword);

            await createCommand.ExecuteNonQueryAsync().ConfigureAwait(false);
        }

        return true;
    }

    public async Task ChangePassword(string newPassword, long currentId)
    {
        const string sqlChangePassword = """
        update admins
        set admin_password = :newPassword
        where admin_id = :currentId;
        """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sqlChangePassword, connection);
        command.AddParameter("newPassword", newPassword);
        command.AddParameter("currentId", currentId);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}