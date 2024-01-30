using AutoMapper;
using ChallengeN.Application.Commands;
using ChallengeN.Application.Queries;
using ChallengeN.Configuration;
using ChallengeN.Domain.Dto.Common;
using ChallengeN.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeN.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PermissionController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<PermissionController> _logger;
    private readonly IMapper _mapper;

    public PermissionController(IMediator mediator, ILogger<PermissionController> logger, IMapper mapper)
    {
        _mediator = mediator;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Permission>> Get(Guid id)
    {
        try
        {
            var record = await _mediator.Send(new GetPermissionQuery(id));
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
    public async Task<ActionResult<ResponseDto>> Post([FromBody] CreatePermissionCommand createPermissionCommand)
    {
        try
        {
            var record = _mapper.Map<ResponseDto>(await _mediator.Send(createPermissionCommand));

            if(record != null)
            {
                _logger.LogInformation($"{nameof(Permission)} with id: {record.Id} has been created");
            }
            else
            {
                _logger.LogInformation($"{nameof(Permission)}  has not been created : {createPermissionCommand}");
            }
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
    public async Task<ActionResult<ResponseDto>> Put(Guid id, [FromBody] UpdatePermissionCommand updatePermissionCommand)
    {
        try
        {
            var record = await _mediator.Send(updatePermissionCommand);

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
