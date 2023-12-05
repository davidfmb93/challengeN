using AutoMapper;
using ChallengeN.Application.Commands;
using ChallengeN.Domain.Interfaces;
using ChallengeN.Domain.Models;
using MediatR;

namespace ChallengeN.Application.Handlers.Commands;
public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, Permission>
{
    private readonly IRepository<Permission> _repositoryPermission;
    private readonly IRepository<RolePermission> _repositoryRolePermission;
    private readonly IMapper _mapper;


    public CreatePermissionCommandHandler(IRepository<Permission> repositoryPermission, IRepository<RolePermission> repositoryRolePermission, IMapper mapper)
    {
        _repositoryPermission = repositoryPermission;
        _repositoryRolePermission = repositoryRolePermission;
        _mapper = mapper;
    }

    public async Task<Permission> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        Permission record = _mapper.Map<Permission>(request);

        _repositoryPermission.Add(record);

        var roles = request.Roles;

        if (roles != null)
        {
            foreach (Guid roleId in roles)
            {
                _repositoryRolePermission.Add(
                    new RolePermission()
                    {
                        RoleId = roleId,
                        PermissionId = record.Id
                    }
                );
            }
        }

        return record;
    }
}
