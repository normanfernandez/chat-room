using Chat_Room.Domain.Chat;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Room.App.Pages
{
    public class RoomsModel : PageModel
    {
        private readonly IChatRoomRepository repository;
        public RoomsModel(IChatRoomRepository repository)
        {
            this.repository = repository;
        }

        public IList<ChatRoom> ChatRoom { get;set; }

        public async Task OnGetAsync()
        {
            ChatRoom = (await repository.GetAllRooms()).ToList();
        }
    }
}
