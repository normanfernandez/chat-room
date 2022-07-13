using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat_Room.Domain.Chat
{
    public interface IChatMessageRepository
    {
        Task SaveChat(ChatMessage chatMessage);
        Task<IEnumerable<ChatMessage>> GetLatestMessagesByRoomId(int roomId);
    }
}
