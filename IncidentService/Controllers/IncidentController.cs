using Common.Dtos;
using IncidentService.Application.Commands.ReportIncident;
using Microsoft.AspNetCore.Mvc;

namespace IncidentService.Controllers
{
    [ApiController]
    [Route("api/incidents")]
    public class IncidentController : ControllerBase
    {
        private readonly ILogger<IncidentController> _logger;
        private readonly ReportIncidentHandler _reportIncidentHandler;

        public IncidentController(ILogger<IncidentController> logger, ReportIncidentHandler reportIncidentHandler)
        {
            _logger = logger;
            _reportIncidentHandler = reportIncidentHandler;
        }

        [HttpPost]
        public async Task<IActionResult> IncidentReported([FromBody] IncidentDto incident)
        {
            if (string.IsNullOrWhiteSpace(incident.Title))
                return BadRequest("Title is required.");

            _logger.LogInformation($"Incident reported: {incident.Title}");

            var command = new ReportIncidentCommand(incident.Title, incident.Description);
            await _reportIncidentHandler.HandleAsync(command);

            return Created(string.Empty, incident);
        }

        [HttpPost("status")]
        public IActionResult IncidentStatusChanged([FromBody] IncidentStatusChangeDto statusChange)
        {
            if (string.IsNullOrWhiteSpace(statusChange.IncidentId) || string.IsNullOrWhiteSpace(statusChange.NewStatus))
            {
                return BadRequest("IncidentId and NewStatus are required.");
            }
            _logger.LogInformation($"Incident status changed: {statusChange.IncidentId} -> {statusChange.NewStatus}");
            return Ok(statusChange);
        }
    }
}
