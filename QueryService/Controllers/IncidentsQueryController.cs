using Microsoft.AspNetCore.Mvc;
using Common.Dtos;

namespace QueryService.Controllers
{
    [ApiController]
    [Route("api/incidents")]
    public class IncidentsQueryController : ControllerBase
    {
        private readonly ILogger<IncidentsQueryController> _logger;

        public IncidentsQueryController(ILogger<IncidentsQueryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetIncidents()
        {
            return Ok();
        }
    }
}
