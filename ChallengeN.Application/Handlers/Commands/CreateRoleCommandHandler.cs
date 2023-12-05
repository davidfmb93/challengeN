using AutoMapper;
using ChallengeN.Application.Commands;
using ChallengeN.Domain.Interfaces;
using ChallengeN.Domain.Models;
using ChallengeN.Infrastructure.Contexts;
using MediatR;
using System.Data;

namespace ChallengeN.Application.Handlers.Commands;
public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Role>
{
    private readonly IRepository<Role> _repository;
    private readonly IRepository<RolePermission> _repositoryRolePermission;

    private readonly IMapper _mapper;


    public CreateRoleCommandHandler(IRepository<Role> repository, IRepository<RolePermission> repositoryRolePermission, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _repositoryRolePermission = repositoryRolePermission;
    }

    public async Task<Role> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        Role record = _mapper.Map<Role>(request);

        _repository.Add(record);

        var permissions = request.Permissions;

        if (permissions != null)
        {
            foreach (Guid permissionId in permissions)
            {
                _repositoryRolePermission.Add(
                    new RolePermission()
                    {
                        RoleId = record.Id,
                        PermissionId = permissionId
                    }
                );
            }
        }


        return record;
    }
}
