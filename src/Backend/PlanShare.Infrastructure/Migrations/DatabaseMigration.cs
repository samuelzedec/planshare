using Dapper;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace PlanShare.Infrastructure.Migrations;

public static class DatabaseMigration
{
    public static void Run(IServiceProvider serviceProvider, string connectionString)
    {
        EnsureDatabaseCreated(connectionString);
        Migrate(serviceProvider);
    }

    private static void EnsureDatabaseCreated(string connectionString)
    {
        var connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);

        var databaseName = connectionStringBuilder.Database;
        connectionStringBuilder.Remove("Database");

        using var connection = new MySqlConnection(connectionStringBuilder.ConnectionString);
        connection.Execute($"CREATE DATABASE IF NOT EXISTS {databaseName}");
    }

    private static void Migrate(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
        runner.ListMigrations();
        runner.MigrateUp();
    }
}