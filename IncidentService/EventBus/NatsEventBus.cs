using Common.EventBus;
using NATS.Client.Core;
using NATS.Client.JetStream;
using System.Text.Json;

public class NatsEventBus : IEventBus
{
    private readonly NatsConnection _connection;
    private readonly NatsJSContext _jetStream;

    public NatsEventBus()
    {
        _connection = new NatsConnection();
        _jetStream = new NatsJSContext(_connection);
    }

    public async Task PublishJetStreamAsync<T>(string subject, T message)
    {
        var json = JsonSerializer.SerializeToUtf8Bytes(message);
        await _jetStream.PublishAsync(subject, json);
    }
}
