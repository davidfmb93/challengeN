using ChallengeN.Application.Commands;
using ChallengeN.Domain.Models;
using ChallengeN.Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN.Application.Handlers.Commands;
public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
{
    private readonly CNDbContext _dbContext;

    public UpdateEmployeeCommandHandler(CNDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var record = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == request.Id);

        if (record == null)
        {
            return default;
        }

        record.FirstName = request.FirstName;
        record.LastName = request.LastName;

        await _dbContext.SaveChangesAsync();

        return record;
    }
}
