using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


var factory = new ConnectionFactory { HostName = "localhost" };

var connection = await factory.CreateConnectionAsync();

using var channel = await connection.CreateChannelAsync();
await channel.QueueDeclareAsync("product", exclusive: false);

var consumer = new AsyncEventingBasicConsumer(channel);

consumer.ReceivedAsync += (model, eventArgs) => 
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Product message received: {message}");
    return Task.CompletedTask;
};

await channel.BasicConsumeAsync(queue: "product", autoAck: true, consumer: consumer);

Console.ReadKey();

