using Application.Features.Devices.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DevicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public DevicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(DeviceResponse),
        StatusCodes.Status201Created)]
    public async Task<ActionResult<DeviceResponse>> CreateDevice(
        [FromBody] CreateDeviceRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateDeviceCommand(
            request.Name,
            request.Type,
            request.RatedPower,
            request.IsSmart ?? false,
            request.IpAddress,
            request.RelayId);

        var result = await _mediator.Send(
            command,
            cancellationToken);

        return CreatedAtAction(
            nameof(GetDevice),
            new { id = result.Id },
            result);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(
        typeof(DeviceResponse),
        StatusCodes.Status200OK)]
    public ActionResult<DeviceResponse> GetDevice(Guid id)
    {
        var response = new DeviceResponse(
            id,
            "DEV-SAMPLE",
            "Sample Device",
            "AC",
            1500m,
            false,
            DeviceStatus.Offline,
            null);

        return Ok(response);
    }

    [HttpPost("{id:guid}/turn-on")]
    [ProducesResponseType(
        typeof(TurnDeviceResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<TurnDeviceResponse>> TurnOnDevice(
        Guid id,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new TurnDeviceOnOffCommand(id, true),
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("{id:guid}/turn-off")]
    [ProducesResponseType(
        typeof(TurnDeviceResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<TurnDeviceResponse>> TurnOffDevice(
        Guid id,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new TurnDeviceOnOffCommand(id, false),
            cancellationToken);

        return Ok(result);
    }
}

public record CreateDeviceRequest(
    string Name,
    string Type,
    decimal RatedPower,
    bool? IsSmart = null,
    string? IpAddress = null,
    string? RelayId = null);
