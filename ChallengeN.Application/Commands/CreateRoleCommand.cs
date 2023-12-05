using ChallengeN.Domain.Models;
using MediatR;

namespace ChallengeN.Application.Commands;
public record CreateRoleCommand : IRequest<Role>
{
    public string? Name { get; set; }
    public IEnumerable<Guid>? Permissions { get; set; }
}
