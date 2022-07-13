using Chat_Room.Domain.Chat;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat_Room.Infraestructure.EF
{
    public class EFChatRoomRepository : IChatRoomRepository
    {
        private ChatRoomDbContext dbContext;

        public EFChatRoomRepository(ChatRoomDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Database.EnsureCreated();
        }

        public async Task<IEnumerable<ChatRoom>> GetAllRooms()
        {
            return await dbContext.ChatRooms.ToListAsync();
        }
    }
}
