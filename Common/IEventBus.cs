namespace Common.EventBus
{
    public interface IEventBus
    {
        void Publish<T>(string subject, T message);
        Task PublishAsync<T>(string subject, T message);
    }
}