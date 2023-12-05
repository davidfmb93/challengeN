using ChallengeN.Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChallengeN.Tests.Scaffolding;

public class WebApplicationTestFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.ConfigureServices(BaseServiceRegistrationOverrides);

        return base.CreateHost(builder);
    }

    protected void BaseServiceRegistrationOverrides(IServiceCollection services)
    {
        var dbContext =
            services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CNDbContext>));

        if (dbContext != null)
        {
            services.Remove(dbContext);
        }

        services.AddDbContext<CNDbContext>(options => options.UseInMemoryDatabase("ChallengeN"));
    }
}
