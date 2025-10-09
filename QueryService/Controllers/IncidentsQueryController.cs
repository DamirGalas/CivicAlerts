using Microsoft.AspNetCore.Mvc;
using Common.Dtos;
using QueryService.Queries;
using QueryService.Application.Handlers;

namespace QueryService.Controllers
{
    [ApiController]
    [Route("api/incidents")]
    public class IncidentsQueryController : ControllerBase
    {
        private readonly ILogger<IncidentsQueryController> _logger;
        private readonly GetIncidentsHandler _getIncidentsHandler;
        private readonly GetIncidentByIdHandler _getIncidentByIdHandler;

        public IncidentsQueryController(
            ILogger<IncidentsQueryController> logger,
            GetIncidentsHandler getIncidentsHandler,
            GetIncidentByIdHandler getIncidentByIdHandler)
        {
            _logger = logger;
            _getIncidentsHandler = getIncidentsHandler;
            _getIncidentByIdHandler = getIncidentByIdHandler;
        }

        // GET /api/incidents
        [HttpGet]
        public async Task<IActionResult> GetIncidents()
        {
            var query = new GetIncidentsQuery();
            var incidents = await _getIncidentsHandler.HandleAsync(query);
            return Ok(incidents);
        }

        // GET /api/incidents/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncidentById(string id)
        {
            var query = new GetIncidentByIdQuery(id);
            var incident = await _getIncidentByIdHandler.HandleAsync(query);
            if (incident == null)
                return NotFound();
            return Ok(incident);
        }
    }
}
