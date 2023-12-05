using ChallengeN.Infrastructure.Mapping;
using System.Reflection;


namespace ChallengeN.Configuration;
public static class AppServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<MappingProfiler>();
        }, Assembly.GetExecutingAssembly());
        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddLogging();

        return services;
    }
}
