using Chat_Room.Domain.Chat;
using Chat_Room.Domain.Chat.Events;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat_Room.Infraestructure.Broker
{
    public class RabbitMQConsumerBackgroundService : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private IChatMessageHandler _handler;

        public RabbitMQConsumerBackgroundService(IChatMessageHandler handler)
        {
            this._handler = handler;
            var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare("chat-room.exchange", ExchangeType.Topic);
            _channel.QueueDeclare("chat-room.queue", false, false, false, null);
            _channel.QueueBind("chat-room.queue", "chat-room.exchange", "chat-room.queue.*", null);
            _channel.BasicQos(0, 1, false);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += OnReceived;

            _channel.BasicConsume("chat-room.queue", false, consumer);
            return Task.CompletedTask;
        }

        private void OnReceived(object sender, BasicDeliverEventArgs args)
        {
            MessageSentEvent @event = JsonConvert.DeserializeObject<MessageSentEvent>(Encoding.UTF8.GetString(args.Body.ToArray()));
            _handler.Handle(@event);
            _channel.BasicAck(args.DeliveryTag, false);
        }
    }
}
