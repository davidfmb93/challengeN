using ChallengeN.Domain.Models.Common;

namespace ChallengeN.Domain.Models;
public record Employee : BaseModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public Guid? RoleId { get; set; }
    public virtual Role? Role {  get; set; } 
}
