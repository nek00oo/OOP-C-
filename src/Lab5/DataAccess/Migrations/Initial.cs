using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create type user_role as enum
    (
        'admin',
        'user'
    );

    create table users
    (
        user_id bigint primary key generated always as identity ,
        user_name text not null ,
        user_role user_role not null 
    );

    create table account
    (
        account_id bigint primary key generated always as identity ,
        account_number bigint not null ,
        account_password text not null ,
        balance bigint not null
        
    );

    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table users;
    drop table account;

    drop type user_role;
    """;
}