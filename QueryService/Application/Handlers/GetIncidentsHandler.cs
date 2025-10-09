using Common.Dtos;
using Common.Queries;
using Microsoft.Extensions.Logging;
using QueryService.Queries;
using CivicAlerts.Data.Repositories;

namespace QueryService.Application.Handlers
{
    public class GetIncidentsHandler : IQueryHandler<GetIncidentsQuery, IEnumerable<IncidentDto>>
    {
        private readonly ILogger<GetIncidentsHandler> _logger;
        private readonly IIncidentRepository _incidentRepository;

        public GetIncidentsHandler(
            ILogger<GetIncidentsHandler> logger,
            IIncidentRepository incidentRepository)
        {
            _logger = logger;
            _incidentRepository = incidentRepository;
        }

        public async Task<IEnumerable<IncidentDto>> HandleAsync(GetIncidentsQuery query)
        {
            _logger.LogInformation("Fetching incidents from read database...");

            // Example usage: fetch all incidents, optionally filter by status
            var incidents = await _incidentRepository.GetAllAsync();
            // Map entity -> DTO
            var result = incidents.Select(i => new IncidentDto
            {
                Id = i.Id,
                Title = i.Title,
                Description = i.Description,
                //CreatedAt = i.CreatedAt
            });

            return result;
        }
    }
}
