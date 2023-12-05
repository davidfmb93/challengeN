using ChallengeN.Domain.Models.Common;

namespace ChallengeN.Domain.Models;
public record Permission : BaseModel
{
    public string? Name { get; set; }

    public virtual ICollection<RolePermission>? RolePermissions { get; set; }
}
