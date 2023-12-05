using ChallengeN.Domain.Models;
using MediatR;

namespace ChallengeN.Application.Commands;
public record UpdatePermissionCommand : IRequest<Permission>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}
