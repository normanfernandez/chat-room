using System;

namespace Chat_Room.Domain.Chat.Events
{
    public class MessageSentEvent
    {
        public int ChatRoomId { get; private set; }
        public int UserId { get; private set; }
        public string Message { get; private set; }
        public DateTime Timestamp { get; private set; } = DateTime.Now;

        public MessageSentEvent(int chatRoomId, int userId, string message)
        {
            ChatRoomId = chatRoomId;
            UserId = userId;
            Message = message;
        }
    }
}
