using AutoMapper;
using ChallengeN.Application.Commands;
using ChallengeN.Domain.Interfaces;
using ChallengeN.Domain.Models;
using ChallengeN.Infrastructure.Contexts;
using MediatR;

namespace ChallengeN.Application.Handlers.Commands;
public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
{
    private readonly IRepository<Employee> _repository;
    private readonly IMapper _mapper;


    public CreateEmployeeCommandHandler(IRepository<Employee> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        Employee record = _mapper.Map<Employee>(request);

        _repository.Add(record);

        return record;
    }
}
