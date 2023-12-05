using ChallengeN.Application.Queries;
using ChallengeN.Domain.Interfaces;
using ChallengeN.Domain.Models;
using MediatR;

namespace ChallengeN.Application.Handlers.Queries;
public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Employee>
{
    private readonly IRepository<Employee> _repository;

    public GetEmployeeQueryHandler(IRepository<Employee> repository)
    {
        _repository = repository;
    }

    public Task<Employee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var record = _repository.Get(request.Id);
        return Task.FromResult(record);
    }
}
