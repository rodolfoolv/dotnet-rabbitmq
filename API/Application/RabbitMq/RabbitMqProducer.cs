using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace API.Application.RabbitMq
{
        public class RabbitMqProducer : IRabbitMqProducer
        {
            public async Task Publish<T>(T message) where T : class
            {

                var factory = new ConnectionFactory { HostName = "localhost" };
                using var connection = await factory.CreateConnectionAsync();
                using var channel = await connection.CreateChannelAsync(); 
                await channel.QueueDeclareAsync("product", exclusive: false);

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);

                await channel.BasicPublishAsync(exchange: "", routingKey: "product", body: body);
            }
        }
}
