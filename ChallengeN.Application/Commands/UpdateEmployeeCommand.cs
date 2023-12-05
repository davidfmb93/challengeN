using ChallengeN.Domain.Models;
using MediatR;

namespace ChallengeN.Application.Commands;
public record UpdateEmployeeCommand : IRequest<Employee>
{
    public Guid? Id { get; set; }
    public Guid? RoleId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
