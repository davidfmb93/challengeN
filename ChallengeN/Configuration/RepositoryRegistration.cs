using ChallengeN.Domain.Interfaces;
using ChallengeN.Domain.Models;
using ChallengeN.Infrastructure.Repositories;


namespace ChallengeN.Configuration;
public static class RepositoryRegistration
{
    public static IServiceCollection AddRepositoryRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IRepository<Employee>, EmployeeRepository>();
        services.AddTransient<IRepository<Permission>, PermissionRepository>();
        services.AddTransient<IRepository<Role>, RoleRepository>();
        services.AddTransient<IRepository<RolePermission>, RolePermissionRepository>();

       

        return services;
    }
}
