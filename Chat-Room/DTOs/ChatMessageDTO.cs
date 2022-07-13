using System.ComponentModel.DataAnnotations;

namespace Chat_Room.DTOs
{
    /// <summary>
    /// DTO for the message sent.
    /// </summary>
    public class ChatMessageDTO
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
