using ChallengeN.Application.Queries;
using ChallengeN.Domain.Interfaces;
using ChallengeN.Domain.Models;
using MediatR;

namespace ChallengeN.Application.Handlers.Queries;
public class GetPermissionQueryHandler : IRequestHandler<GetPermissionQuery, Permission>
{
    private readonly IRepository<Permission> _repository;

    public GetPermissionQueryHandler(IRepository<Permission> repository)
    {
        _repository = repository;
    }

    public Task<Permission> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
    {
        var record = _repository.Get(request.Id);
        return Task.FromResult(record);
    }
}
