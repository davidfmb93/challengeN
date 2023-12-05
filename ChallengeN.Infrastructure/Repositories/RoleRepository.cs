using ChallengeN.Domain.Interfaces;
using ChallengeN.Domain.Models;
using ChallengeN.Infrastructure.Contexts;

namespace ChallengeN.Infrastructure.Repositories;
public class RoleRepository : IRepository<Role>
{
    private readonly CNDbContext _dbContext;

    public RoleRepository(CNDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Role? Get(Guid recordId)
    {
        return _dbContext.Roles.FirstOrDefault(e => e.Id == recordId);
    }

    public Role? Add(Role record)
    {
        _dbContext.Roles.Add(record);
        _dbContext.SaveChanges();
        return record;
    }

    public Role? Update(Role record)
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
