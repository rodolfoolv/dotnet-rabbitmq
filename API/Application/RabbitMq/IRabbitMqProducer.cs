namespace API.Application.RabbitMq
{
    public interface IRabbitMqProducer
    {
        Task Publish<T>(T message) where T : class;
    }
}
