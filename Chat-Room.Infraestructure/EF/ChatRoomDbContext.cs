using Chat_Room.Domain.Chat;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chat_Room.Infraestructure.EF
{
    public class ChatRoomDbContext : DbContext
    {
        public ChatRoomDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var charMessageEntity = modelBuilder.Entity<ChatMessage>();

            charMessageEntity
                .HasData(new ChatMessage { UserId = BotChatMessage.BOT_USER_ID, RoomId = 1, Content = "Ohayo~", Id = 1 });

            charMessageEntity
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            var chatRoomEntity = modelBuilder.Entity<ChatRoom>();
            chatRoomEntity
                .HasData(new ChatRoom { Id = 1, Description = "#MonasChinas" }, new ChatRoom { Id = 2, Description = "/b" });
            chatRoomEntity
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
