using System.ComponentModel.DataAnnotations;

namespace Chat_Room.Domain.Chat
{
    public class ChatRoom
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
