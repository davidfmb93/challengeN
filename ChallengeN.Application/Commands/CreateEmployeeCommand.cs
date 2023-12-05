using ChallengeN.Domain.Models;
using MediatR;

namespace ChallengeN.Application.Commands;
public record CreateEmployeeCommand : IRequest<Employee>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Guid? RoleId { get; set; }
}
