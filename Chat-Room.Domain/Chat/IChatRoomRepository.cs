using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat_Room.Domain.Chat
{
    public interface IChatRoomRepository
    {
        Task<IEnumerable<ChatRoom>> GetAllRooms();
    }
}
