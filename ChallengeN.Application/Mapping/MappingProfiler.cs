using AutoMapper;
using ChallengeN.Application.Commands;
using ChallengeN.Domain.Dto.Common;
using ChallengeN.Domain.Models;

namespace ChallengeN.Infrastructure.Mapping;
public class MappingProfiler : Profile
{
    public MappingProfiler()
    {
        CreateMap<CreateEmployeeCommand, Employee>();
        CreateMap<UpdateEmployeeCommand, Employee>();
        CreateMap<Employee, ResponseDto>();

        CreateMap<CreatePermissionCommand, Permission>();
        CreateMap<UpdatePermissionCommand, Permission>();
        CreateMap<Permission, ResponseDto>();

        CreateMap<CreateRoleCommand, Role>();
        CreateMap<UpdateRoleCommand, Role>();
        CreateMap<Role, ResponseDto>();
    }
}
