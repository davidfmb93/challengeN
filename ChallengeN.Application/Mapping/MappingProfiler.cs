using AutoMapper;
using ChallengeN.Application.Commands;
using ChallengeN.Domain.Models;

namespace ChallengeN.Infrastructure.Mapping;
public class MappingProfiler : Profile
{
    public MappingProfiler()
    {
        CreateMap<CreateEmployeeCommand, Employee>();
        CreateMap<UpdateEmployeeCommand, Employee>();

        CreateMap<CreatePermissionCommand, Permission>();
        CreateMap<UpdatePermissionCommand, Permission>();

        CreateMap<CreateRoleCommand, Role>();
        CreateMap<UpdateRoleCommand, Role>();

    }
}
