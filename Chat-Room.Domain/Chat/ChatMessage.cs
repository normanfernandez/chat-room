using System;
using System.ComponentModel.DataAnnotations;

namespace Chat_Room.Domain.Chat
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public bool IsCommand 
        {
            get => !string.IsNullOrEmpty(Content) && Content.StartsWith('/');
        }
    }
}
