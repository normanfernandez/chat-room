using Chat_Room.Domain.Chat;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Chat_Room.Infraestructure.Hubs
{
    public class ChatHub : Hub
    {
        public IServiceProvider Services { get; private set; }

        public ChatHub(IServiceProvider services)
        {
            Services = services;
        }

        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.SendAsync("MessageSentEvent", message.UserEmail, message.Content, message.Timestamp.ToString("g", CultureInfo.InvariantCulture), message.RoomId);
        }
    }
}
