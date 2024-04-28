using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrustructure.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create table if not exists users
    (
        id bigint primary key generated always as identity ,
        name text not null ,
        salt text not null , 
        password_hash text ,
        role text
    );

    create table if not exists bank_accounts
    (
        id bigint primary key generated always as identity ,
        account_id bigint ,
        value bigint
    );

    create table if not exists bank_accounts_operations
    (
        bank_account_id bigint not null ,
        type text ,
        amount bigint not null 
    );

    insert into users (name, salt, password_hash, role)
    select 'name', 'axfkgmwolfapkfwp', 'eb9e837ff741c1cd9c216df84234c8d468b1286da87f6c73b7df402d41e981d8', 'admin'
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table users;
    drop table bank_accounts;
    drop table bank_account_operations;
    """;
}