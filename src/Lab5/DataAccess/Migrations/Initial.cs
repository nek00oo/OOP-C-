using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create table user_account
    (
        account_id bigint primary key generated always as identity ,
        account_number bigint not null ,
        account_password text not null ,
        balance bigint not null ,
            
        unique (account_number)
        
    );
    
    create table admins
    (
        admin_id bigint primary key generated always as identity ,
        admin_password text not null,
        
        unique (admin_password)
    );
    
    create table history_operations
    (
        operation_id bigint primary key generated always as identity ,
        account_id bigint not null references user_account(account_id) ,
        operation text not null
        
    )

    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table user_account;
    drop table admins;
    drop table history_operations

    """;
}