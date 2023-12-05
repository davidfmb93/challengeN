using ChallengeN.Domain.Models.Common;

namespace ChallengeN.Domain.Models;

public record Role : BaseModel
{
    public string? Name { get; set; }

    public virtual ICollection<Employee>? Employees { get; set; }
    public virtual ICollection<RolePermission>? RolePermissions { get; set; }
}
