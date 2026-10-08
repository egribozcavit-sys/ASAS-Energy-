using Application.Features.Energy.Commands;
using Application.Features.Energy.Queries;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnergyController : ControllerBase
{
    private readonly IMediator _mediator;

    public EnergyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("current")]
    [ProducesResponseType(
        typeof(EnergyReadingsResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<EnergyReadingsResponse>>
        GetCurrentReadings(CancellationToken cancellationToken)
    {
        var userId = Guid.NewGuid();

        var result = await _mediator.Send(
            new GetCurrentReadingsQuery(userId),
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("optimize")]
    [ProducesResponseType(
        typeof(OptimizationResult),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<OptimizationResult>>
        OptimizeEnergy(
            [FromBody] OptimizeEnergyRequest request,
            CancellationToken cancellationToken)
    {
        var userId = Guid.NewGuid();

        var result = await _mediator.Send(
            new OptimizeEnergyCommand(
                userId,
                request.From,
                request.To),
            cancellationToken);

        return Ok(result);
    }
}

public record OptimizeEnergyRequest(
    DateTime From,
    DateTime To);
