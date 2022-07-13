using System;

namespace Chat_Room.Domain.Chat.Events
{
    public class MessageSentEvent
    {
        public int ChatRoomId { get; private set; }
        public string UserEmail { get; private set; }
        public string Message { get; private set; }
        public DateTime Timestamp { get; private set; } = DateTime.Now;

        public MessageSentEvent(int chatRoomId, string userEmail, string message)
        {
            ChatRoomId = chatRoomId;
            UserEmail = userEmail;
            Message = message;
        }
    }
}
