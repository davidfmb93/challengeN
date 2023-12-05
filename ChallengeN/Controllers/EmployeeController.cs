using ChallengeN.Application.Commands;
using ChallengeN.Application.Queries;
using ChallengeN.Configuration;
using ChallengeN.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeN.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(IMediator mediator, ILogger<EmployeeController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> Get(Guid id)
    {
        try
        {
            var record = await _mediator.Send(new GetEmployeeQuery(id));
            return Ok(record);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Problem(AppOptions.InternalServerErrorMessage, statusCode: 500);
        }
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<Permission>> Post([FromBody] CreateEmployeeCommand createEmployeeCommand)
    {
        try
        {
            var record = await _mediator.Send(createEmployeeCommand);
            return CreatedAtAction(nameof(Post), record);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Problem(AppOptions.InternalServerErrorMessage, statusCode: 500);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<Permission>> Put(Guid id, [FromBody] UpdateEmployeeCommand updateEmployeeCommand)
    {
        try
        {
            var record = await _mediator.Send(updateEmployeeCommand);

            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Problem(AppOptions.InternalServerErrorMessage, statusCode: 500);
        }
    }
}
