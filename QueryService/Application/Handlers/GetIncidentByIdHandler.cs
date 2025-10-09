using System;
using System.Threading.Tasks;
using Common.Dtos;
using Common.Queries;
using Microsoft.Extensions.Logging;
using QueryService.Queries;
using CivicAlerts.Data.Repositories;

namespace QueryService.Application.Handlers
{
    public class GetIncidentByIdHandler : IQueryHandler<GetIncidentByIdQuery, IncidentDto?>
    {
        private readonly ILogger<GetIncidentByIdHandler> _logger;
        private readonly IIncidentRepository _incidentRepository;

        public GetIncidentByIdHandler(
            ILogger<GetIncidentByIdHandler> logger,
            IIncidentRepository incidentRepository)
        {
            _logger = logger;
            _incidentRepository = incidentRepository;
        }

        public async Task<IncidentDto?> HandleAsync(GetIncidentByIdQuery query)
        {
            _logger.LogInformation($"Fetching incident with ID: {query.IncidentId}");

            var incident = await _incidentRepository.GetByIdAsync(query.IncidentId);
            if (incident == null)
                return null;

            // Map Incident to IncidentDto
            var dto = new IncidentDto
            {
                Id = incident.Id,
                Title = incident.Title,
                Description = incident.Description,
                Category = "", // Map if available in Incident
                Location = "", // Map if available in Incident
                Reporter = ""  // Map if available in Incident
            };

            return dto;
        }
    }
}