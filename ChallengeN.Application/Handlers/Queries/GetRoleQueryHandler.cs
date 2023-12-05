using ChallengeN.Application.Queries;
using ChallengeN.Domain.Interfaces;
using ChallengeN.Domain.Models;
using MediatR;

namespace ChallengeN.Application.Handlers.Queries;
public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, Role>
{
    private readonly IRepository<Role> _repository;

    public GetRoleQueryHandler(IRepository<Role> repository)
    {
        _repository = repository;
    }

    public Task<Role> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        var record = _repository.Get(request.Id);
        return Task.FromResult(record);
    }
}
