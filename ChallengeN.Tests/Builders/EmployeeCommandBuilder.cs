using ChallengeN.Application.Commands;

namespace Publicis.Roar.RM.Tests.Builders;

public class EmployeeCommandBuilder
{
    private UpdateEmployeeCommand _dto = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "TestFirstName",
        LastName = "TestLastName",
    };

    public UpdateEmployeeCommand Build() => _dto;

    public EmployeeCommandBuilder WithId(Guid id)
    {
        _dto = _dto with { Id = id };
        return this;
    }

    public EmployeeCommandBuilder WithFirstName(string firstName)
    {
        _dto = _dto with { FirstName = firstName };
        return this;
    }

    public EmployeeCommandBuilder WithLastName(string firstName)
    {
        _dto = _dto with { LastName = firstName };
        return this;
    }


}
