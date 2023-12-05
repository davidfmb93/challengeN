using ChallengeN.Domain.Models;
using MediatR;

namespace ChallengeN.Application.Commands;
public record UpdateRoleCommand : IRequest<Role>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}
