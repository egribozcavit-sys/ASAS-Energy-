using Application.Features.Alerts.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlertsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AlertsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(
        typeof(List<AlertResponse>),
        StatusCodes.Status200OK)]
    public ActionResult<List<AlertResponse>> GetAlerts()
    {
        return Ok(new List<AlertResponse>());
    }

    [HttpPost("{id:guid}/acknowledge")]
    [ProducesResponseType(
        typeof(AcknowledgeAlertResponse),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<AcknowledgeAlertResponse>>
        AcknowledgeAlert(
            Guid id,
            CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new AcknowledgeAlertCommand(id),
            cancellationToken);

        return Ok(result);
    }
}

public record AlertResponse(
    Guid Id,
    string AlertId,
    string Title,
    string Message,
    string Severity,
    string Type,
    bool IsRead,
    DateTime CreatedAt,
    Guid? DeviceId);
