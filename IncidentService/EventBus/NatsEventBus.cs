using NATS.Client;
using System.Text.Json;
using Common.EventBus;

public class NatsEventBus : IEventBus
{
    private readonly IConnection _connection;

    public NatsEventBus()
    {
        var options = ConnectionFactory.GetDefaultOptions();
        options.Url = "nats://localhost:4222";
        _connection = new ConnectionFactory().CreateConnection(options);
    }

    public void Publish<T>(string subject, T message)
    {
        var json = JsonSerializer.Serialize(message);
        _connection.Publish(subject, System.Text.Encoding.UTF8.GetBytes(json));
    }

    public async Task PublishAsync<T>(string subject, T message)
    {
        var json = JsonSerializer.Serialize(message);
        var data = System.Text.Encoding.UTF8.GetBytes(json);
        await Task.Run(() => _connection.Publish(subject, data));
    }

    public async Task PublishJetStreamAsync<T>(string subject, T message)
    {
        var json = JsonSerializer.Serialize(message);
        var data = System.Text.Encoding.UTF8.GetBytes(json);
        var jetStream = _connection.CreateJetStreamContext();
        await Task.Run(() =>
        {
            jetStream.Publish(subject, data);
        });
    }
}
