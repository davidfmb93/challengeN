using ChallengeN.Domain.Interfaces;
using ChallengeN.Domain.Models;
using ChallengeN.Infrastructure.Contexts;

namespace ChallengeN.Infrastructure.Repositories;
public class PermissionRepository : IRepository<Permission>
{
    private readonly CNDbContext _dbContext;

    public PermissionRepository(CNDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Permission? Get(Guid recordId)
    {
        return _dbContext.Permissions.FirstOrDefault(e => e.Id == recordId);
    }

    public Permission? Add(Permission record)
    {
        _dbContext.Permissions.Add(record);
        _dbContext.SaveChanges();

        return record;
    }

    public Permission? Update(Permission record)
    {
        var element = Get(record.Id);

        if (element != null)
        {
            element.Name = record.Name;

            _dbContext.SaveChanges();

            return record;
        }

        return null;
    }
}
