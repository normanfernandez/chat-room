using Chat_Room.Domain.Broker;
using Chat_Room.Domain.Chat;
using Chat_Room.Domain.Chat.Events;
using Chat_Room.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chat_Room.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        private readonly IMessagePublisher _messagePublisher;
        private readonly IChatMessageRepository _repository;
        public PublishController(IMessagePublisher messagePublisher, IChatMessageRepository repository)
        {
            _messagePublisher = messagePublisher;
            _repository = repository;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] ChatMessageDTO body)
        {
            ChatMessage chat = new ChatMessage
            {
                Content = body.Content,
                RoomId = body.RoomId,
                UserId = body.UserId
            };

            // If not command, then do not persist.
            if (!chat.IsCommand)
            {
                await _repository.SaveChat(chat);
            }
            await _messagePublisher.Publish(new MessageSentEvent(body.RoomId, body.UserId, body.Content));

            return Ok();
        }
    }
}
