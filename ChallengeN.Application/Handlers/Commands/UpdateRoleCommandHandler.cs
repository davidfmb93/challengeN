using AutoMapper;
using ChallengeN.Application.Commands;
using ChallengeN.Domain.Interfaces;
using ChallengeN.Domain.Models;
using MediatR;

namespace ChallengeN.Application.Handlers.Commands;
public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Role>
{
    private readonly IRepository<Role> _repository;
    private readonly IMapper _mapper;

    public UpdateRoleCommandHandler(IRepository<Role> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Role> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        Role recordRole = _mapper.Map<Role>(request);
        Role record = _repository.Get(recordRole.Id);

        if (record == null)
        {
            return default;
        }

        record.Name = request.Name;

        record = _repository.Update(record);

        return record;
    }
}
