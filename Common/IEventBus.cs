namespace Common.EventBus
{
    public interface IEventBus
    {
        Task PublishJetStreamAsync<T>(string subject, T message);
    }
}