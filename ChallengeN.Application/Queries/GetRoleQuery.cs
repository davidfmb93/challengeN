using ChallengeN.Domain.Models;
using MediatR;

namespace ChallengeN.Application.Queries
{
    public record GetRoleQuery(Guid Id) : IRequest<Role>;
}
