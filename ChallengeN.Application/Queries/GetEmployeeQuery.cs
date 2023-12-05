using ChallengeN.Domain.Models;
using MediatR;

namespace ChallengeN.Application.Queries
{
    public record GetEmployeeQuery(Guid Id) : IRequest<Employee>;
}
