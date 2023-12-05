using ChallengeN.Domain.Models;
using MediatR;

namespace ChallengeN.Application.Queries
{
    public record GetPermissionQuery(Guid Id) : IRequest<Permission>;
}
