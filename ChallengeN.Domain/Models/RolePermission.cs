using ChallengeN.Domain.Models.Common;

namespace ChallengeN.Domain.Models;

public record RolePermission : BaseModel
{
    public Guid RoleId { get; set; }
    public virtual Role? Role { get; set; }

    public Guid PermissionId { get; set; }
    public virtual Permission? Permission { get; set; }
}
