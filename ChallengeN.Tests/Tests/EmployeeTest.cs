using ChallengeN.Application.Commands;
using ChallengeN.Domain.Models;
using ChallengeN.Infrastructure.Contexts;
using ChallengeN.Tests.Scaffolding;
using Microsoft.VisualBasic;
using Publicis.Roar.RM.Tests.Builders;

namespace ChallengeN.Tests;

[Collection("Employees")]
public class EmployeeApiTests : TestBase
{
    private const string ApiPath = "/api/Employee";

    private readonly CNDbContext _context;
    private readonly EmployeeCommandBuilder _employeeCommandBuilder;

    public EmployeeApiTests()
    {
        _context = DbContext;
        _employeeCommandBuilder = new EmployeeCommandBuilder();
    }

    [Fact]
    public async Task ShouldCreateANewEmployee()
    {
        var command = _employeeCommandBuilder.Build();

        var response = await SendRequestAsync<Employee>("Post", command, ApiPath);
        var persistedEmployee = _context.Employees.SingleOrDefault(rc => rc.Id == response.Id);

        AssertEmployee(persistedEmployee, command);
    }

    [Fact]
    public async Task ShouldUpdateEmployeee()
    {
        var command = _employeeCommandBuilder.Build();

        //create record to do test
        var responseCreated = await SendRequestAsync<Employee>("Post", command, ApiPath);

        var updatedCommand = _employeeCommandBuilder
            .WithId(responseCreated.Id)
            .WithFirstName("David")
            .WithLastName("Martinez")
            .Build();

        var responseUpdated = await SendRequestAsync<Employee>("Put", updatedCommand, $"{ApiPath}/{responseCreated.Id}");

        var persistedEmployee = _context.Employees.SingleOrDefault(rc => rc.Id == responseUpdated.Id);

        AssertEmployee(persistedEmployee, updatedCommand);
    }

    private void AssertEmployee(Employee? persisted, UpdateEmployeeCommand expected)
    {
        persisted.ShouldNotBeNull();
        persisted.FirstName.ShouldBe(expected.FirstName);
        persisted.LastName.ShouldBe(expected.LastName);
    }
}
