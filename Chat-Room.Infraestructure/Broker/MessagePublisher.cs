using Chat_Room.Domain.Broker;
using Chat_Room.Domain.Chat;
using Chat_Room.Domain.Chat.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Room.Infraestructure.Broker
{
    public class MessagePublisher : IMessagePublisher
    {
        private IConnection _connection;
        private IModel _channel;

        public MessagePublisher()
        {
            var factory = new ConnectionFactory { HostName = "localhost", UserName = "pony", Password = "pony" };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare("chat-room.exchange", ExchangeType.Topic);
            _channel.QueueDeclare("chat-room.queue", false, false, false, null);
            _channel.QueueBind("chat-room.queue", "chat-room.exchange", "chat-room.queue.*", null);
            _channel.BasicQos(0, 1, false);
        }
        public Task Publish(MessageSentEvent message)
        {
            string json = JsonConvert.SerializeObject(message);
            byte[] payload = Encoding.UTF8.GetBytes(json);
            _channel.BasicPublish(exchange: "", routingKey: "chat-room.queue", body: payload);
            return Task.CompletedTask;
        }
    }
}
