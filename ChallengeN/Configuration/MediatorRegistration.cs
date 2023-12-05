using ChallengeN.Application.Commands;
using ChallengeN.Application.Handlers.Commands;
using ChallengeN.Application.Handlers.Queries;
using ChallengeN.Application.Queries;
using ChallengeN.Domain.Models;
using MediatR;


namespace ChallengeN.Configuration;
public static class MediatorRegistration
{
    public static IServiceCollection AddMediatorRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        ////Commands Mediators
        services.AddTransient<IRequestHandler<CreateEmployeeCommand, Employee>, CreateEmployeeCommandHandler>();
        services.AddTransient<IRequestHandler<UpdateEmployeeCommand, Employee>, UpdateEmployeeCommandHandler>();

        services.AddTransient<IRequestHandler<CreatePermissionCommand, Permission>, CreatePermissionCommandHandler>();
        services.AddTransient<IRequestHandler<UpdatePermissionCommand, Permission>, UpdatePermissionCommandHandler>();

        services.AddTransient<IRequestHandler<CreateRoleCommand, Role>, CreateRoleCommandHandler>();
        services.AddTransient<IRequestHandler<UpdateRoleCommand, Role>, UpdateRoleCommandHandler>();

        ////Queries Mediators
        services.AddTransient<IRequestHandler<GetEmployeeQuery, Employee>, GetEmployeeQueryHandler>();
        services.AddTransient<IRequestHandler<GetPermissionQuery, Permission>, GetPermissionQueryHandler>();
        services.AddTransient<IRequestHandler<GetRoleQuery, Role>, GetRoleQueryHandler>();

        return services;
    }
}
