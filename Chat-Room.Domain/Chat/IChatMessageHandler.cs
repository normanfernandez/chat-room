using Chat_Room.Domain.Chat.Events;
using System.Threading.Tasks;

namespace Chat_Room.Domain.Chat
{
    public interface IChatMessageHandler
    {
        Task Handle(MessageSentEvent @event);
    }
}
