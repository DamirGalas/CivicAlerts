using Common.Dtos;
using Common.Queries;
using Microsoft.Extensions.Logging;
using QueryService.Queries;

namespace QueryService.Application.Handlers
{
    public class GetIncidentsHandler : IQueryHandler<GetIncidentsQuery, IEnumerable<IncidentDto>>
    {
        private readonly ILogger<GetIncidentsHandler> _logger;

        public GetIncidentsHandler(ILogger<GetIncidentsHandler> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<IncidentDto>> HandleAsync(GetIncidentsQuery query)
        {
            _logger.LogInformation("Fetching incidents from read database...");

            if (string.IsNullOrWhiteSpace(query.Status))
                return null;

            return null;
        }
    }
}
