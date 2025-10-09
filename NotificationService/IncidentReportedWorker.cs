using Common.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NATS.Client.Core;
using NATS.Client.JetStream;
using NATS.Client.JetStream.Models;
using System.IO;
using System.Text;
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
        var js = new NatsJSContext(_nats);
        var stream = await js.GetStreamAsync("INCIDENTS_STREAM", cancellationToken: stoppingToken);
        var consumer = await stream.GetConsumerAsync("all-incidents", cancellationToken: stoppingToken);

        await foreach (var msg in consumer.FetchAsync<byte[]>(
            opts: new NatsJSFetchOpts { MaxMsgs = 10 },
            cancellationToken: stoppingToken))
        {
            try
            {
                var json = System.Text.Encoding.UTF8.GetString(msg.Data);
                var incident = JsonSerializer.Deserialize<IncidentReportedEvent>(
                    json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                _logger.LogInformation($"Received incident: {incident?.Title} - {incident?.Description}");
                await msg.AckAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing incident message");
            }
        }
    }
}
