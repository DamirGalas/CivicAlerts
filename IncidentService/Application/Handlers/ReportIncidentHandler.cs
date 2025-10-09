using Common.Events;
using Common;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Common.EventBus;
using IncidentService.Application.Commands;

namespace IncidentService.Application.Handlers
{
    public class ReportIncidentHandler
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<ReportIncidentHandler> _logger;

        public ReportIncidentHandler(IEventBus eventBus, ILogger<ReportIncidentHandler> logger)
        {
            _eventBus = eventBus;
            _logger = logger;
        }

        public async Task HandleAsync(ReportIncidentCommand command)
        {
            var incidentEvent = new IncidentReportedEvent
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow,
                Title = command.Title,
                Description = command.Description
            };
                await _eventBus.PublishJetStreamAsync("incident.reported", incidentEvent);
            _logger.LogInformation($"Incident reported: {incidentEvent.Id} - {incidentEvent.Title}");
        }
    }
}
