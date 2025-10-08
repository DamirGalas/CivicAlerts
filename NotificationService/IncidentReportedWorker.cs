using Common.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NATS.Client.Core;
using System.Text.Json;

public class IncidentReportedWorker : BackgroundService
{
    private readonly ILogger<IncidentReportedWorker> _logger;
    private readonly NatsConnection _nats;

    public IncidentReportedWorker(ILogger<IncidentReportedWorker> logger)
    {
        _logger = logger;
        _nats = new NatsConnection();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("NotificationService started.");

        await foreach (var msg in _nats.SubscribeAsync<byte[]>("incident.reported", cancellationToken: stoppingToken))
        {
            var incident = JsonSerializer.Deserialize<IncidentReportedEvent>(msg.Data);
            _logger.LogInformation($"Received incident: {incident?.Description}");
        }
    }
}
