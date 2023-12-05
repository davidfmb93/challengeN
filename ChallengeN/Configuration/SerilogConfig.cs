namespace ChallengeN.Configuration;
public static class SerilogConfig
{
    public static IServiceCollection AddSerilogConfig(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
