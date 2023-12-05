using ChallengeN.Domain.Interfaces;
using ChallengeN.Domain.Models;
using ChallengeN.Infrastructure.Contexts;

namespace ChallengeN.Infrastructure.Repositories;
public class RolePermissionRepository : IRepository<RolePermission>
{
    private readonly CNDbContext _dbContext;

    public RolePermissionRepository(CNDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public RolePermission? Get(Guid recordId)
    {
        return _dbContext.RolePermissions.FirstOrDefault(e => e.Id == recordId);
    }

    public RolePermission? Add(RolePermission record)
    {
        _dbContext.RolePermissions.Add(record);
        _dbContext.SaveChanges();
        return record;
    }

    public RolePermission? Update(RolePermission record)
    {
        var element = Get(record.Id);

        if (element != null)
        {
            element.PermissionId = record.PermissionId;
            element.RoleId = record.RoleId;

            _dbContext.SaveChanges();

            return record;
        }

        return null;
    }
}
