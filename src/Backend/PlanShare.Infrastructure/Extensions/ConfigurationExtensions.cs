using Microsoft.Extensions.Configuration;

namespace PlanShare.Infrastructure.Extensions;

public static class ConfigurationExtensions
{
    public static string ConnectionString(this IConfiguration configuration)
        => configuration.GetConnectionString("ConnectionMySql")!;

    public static bool IsUnitTestEnviroment(this IConfiguration configuration)
    {
        _ = bool.TryParse(configuration.GetSection("InMemoryTests").Value, out var inMemoryTests);
        return inMemoryTests;
    }
}