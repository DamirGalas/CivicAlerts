using Common.EventBus;
using Common.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IncidentService.Application.Commands.IncidentStatusChanged
{
    public class IncidentStatusChangedHandler
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<IncidentStatusChangedHandler> _logger;

        public IncidentStatusChangedHandler(IEventBus eventBus, ILogger<IncidentStatusChangedHandler> logger)
        {
            _eventBus = eventBus;
            _logger = logger;
        }

        public async Task HandleAsync(IncidentStatusChangedCommand command)
        {
            var statusEvent = new IncidentStatusChangedEvent
            {
                IncidentId = command.IncidentId,
                NewStatus = command.NewStatus,
                ChangedAt = DateTime.UtcNow
            };
            await _eventBus.PublishJetStreamAsync<IncidentStatusChangedEvent>("incident.status.changed", statusEvent);
            _logger.LogInformation($"Incident status changed: {statusEvent.IncidentId} -> {statusEvent.NewStatus}");
        }
    }
}
