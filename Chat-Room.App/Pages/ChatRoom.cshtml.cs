using Chat_Room.Domain.Chat;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Room.App.Pages
{
    public class ChatRoomModel : PageModel
    {
        private IChatMessageRepository chatMessageRepository;
        private IChatRoomRepository chatRoomRepository;

        public ChatRoomModel(IChatMessageRepository chatMessageRepository, IChatRoomRepository chatRoomRepository)
        {
            this.chatMessageRepository = chatMessageRepository;
            this.chatRoomRepository = chatRoomRepository;
        }

        public IList<ChatMessage> ChatMessage { get;set; }
        public int RoomId { get; set; }
        public string UserEmail { get; set; }

        public async Task OnGetAsync(int id)
        {
            var rooms = await chatRoomRepository.GetAllRooms();
            if (!rooms.Any(r => r.Id == id))
            {
                StatusCode(404);
                return;
            }
            ChatMessage = (await chatMessageRepository.GetLatestMessagesByRoomId(id)).ToList();
            UserEmail = this.User.Identity.Name;
            RoomId = id;
        }
    }
}
