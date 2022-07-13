using Chat_Room.Domain.Chat;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Room.Infraestructure.EF
{
    public class EFChatMessageRepository : IChatMessageRepository
    {
        private ChatRoomDbContext dbContext;

        public EFChatMessageRepository(ChatRoomDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Database.EnsureCreated();
        }

        public async Task<IEnumerable<ChatMessage>> GetLatestMessagesByRoomId(int roomId)
        {
            // Get chats sorted by timestamp DESC and only 50.
            return (await dbContext.ChatMessages
                .ToListAsync()) // To list first, bug using InMemory.
                .Where(r => r.RoomId == roomId)
                .OrderByDescending(r => r.Timestamp)
                .TakeLast(50);
        }

        public async Task SaveChat(ChatMessage chatMessage)
        {
            await dbContext.ChatMessages.AddAsync(chatMessage);
            await dbContext.SaveChangesAsync();
        }
    }
}
