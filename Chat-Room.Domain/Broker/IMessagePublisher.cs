using Chat_Room.Domain.Chat.Events;
using System.Threading.Tasks;

namespace Chat_Room.Domain.Broker
{
    public interface IMessagePublisher
    {
        Task Publish(MessageSentEvent messageSentEvent);
    }
}
