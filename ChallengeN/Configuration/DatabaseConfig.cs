using ChallengeN.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN.Configuration;
public static class DatabaseConfig
{
    public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CNDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnection"))
        );
        return services;
    }
}
