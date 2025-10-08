using Common.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NATS.Client.Core;
using System.Text.Json;

public class IncidentStatusChangedWorker : BackgroundService
{
    private readonly ILogger<IncidentStatusChangedWorker> _logger;
    private readonly NatsConnection _nats;

    public IncidentStatusChangedWorker(ILogger<IncidentStatusChangedWorker> logger)
    {
        _logger = logger;
        _nats = new NatsConnection();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("IncidentStatusChangedWorker started.");

        await foreach (var msg in _nats.SubscribeAsync<byte[]>("incident.status.changed", cancellationToken: stoppingToken))
        {
            var statusEvent = JsonSerializer.Deserialize<IncidentStatusChangedEvent>(msg.Data);
            _logger.LogInformation($"Incident status changed: {statusEvent?.IncidentId} -> {statusEvent?.NewStatus} at {statusEvent?.ChangedAt}");
        }
    }
}
