using System;
using System.Threading.Tasks;
using Common.Dtos;
using Common.Queries;
using Microsoft.Extensions.Logging;
using QueryService.Queries;

namespace QueryService.Application.Handlers
{
    public class GetIncidentByIdHandler : IQueryHandler<GetIncidentByIdQuery, IncidentDto?>
    {
        private readonly ILogger<GetIncidentByIdHandler> _logger;

        public GetIncidentByIdHandler(ILogger<GetIncidentByIdHandler> logger)
        {
            _logger = logger;
        }

        public async Task<IncidentDto?> HandleAsync(GetIncidentByIdQuery query)
        {
            _logger.LogInformation($"Fetching incident with ID: {query.IncidentId}");

            await Task.CompletedTask;
            return null;
        }
    }
}