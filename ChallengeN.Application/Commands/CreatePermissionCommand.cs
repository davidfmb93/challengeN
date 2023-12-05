using ChallengeN.Domain.Models;
using MediatR;

namespace ChallengeN.Application.Commands;
public record CreatePermissionCommand : IRequest<Permission>
{
    public string? Name { get; set; }
    public IEnumerable<Guid>? Roles { get; set; }
}
