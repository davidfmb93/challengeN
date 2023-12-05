using AutoMapper;
using ChallengeN.Application.Commands;
using ChallengeN.Domain.Interfaces;
using ChallengeN.Domain.Models;
using MediatR;

namespace ChallengeN.Application.Handlers.Commands;
public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, Permission>
{
    private readonly IRepository<Permission> _repository;
    private readonly IMapper _mapper;

    public UpdatePermissionCommandHandler(IRepository<Permission> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Permission> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
    {
        Permission recordPermission = _mapper.Map<Permission>(request);
        Permission record = _repository.Get(recordPermission.Id);

        if (record == null)
        {
            return default;
        }

        record.Name = request.Name;

        record = _repository.Update(record);

        return record;
    }
}
