using ChallengeN.Domain.Interfaces;
using ChallengeN.Domain.Models;
using ChallengeN.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN.Infrastructure.Repositories;
public class EmployeeRepository : IRepository<Employee>
{
    private readonly CNDbContext _dbContext;

    public EmployeeRepository(CNDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Employee? Get(Guid employeeId)
    {
        return _dbContext.Employees
            .Include(e => e.Role)
            .FirstOrDefault(e => e.Id == employeeId);
    }

    public Employee? Add(Employee record)
    {
        _dbContext.Employees.Add(record);
        _dbContext.SaveChanges();

        return record;
    }

    public Employee? Update(Employee employee)
    {
        var record = _dbContext.Employees.Find(employee.Id);

        if (record != null)
        {
            record.FirstName = employee.FirstName;
            record.LastName = employee.LastName;

            _dbContext.SaveChanges();

            return record;
        }

        return null;
    }
}
