using Chat_Room.Domain.Chat;
using Chat_Room.Domain.Chat.Events;
using Chat_Room.Domain.Commands;
using Chat_Room.Domain.Stocks;
using Chat_Room.Infraestructure.Hubs;
using Chat_Room.Infraestructure.Stocks;
using System.Threading.Tasks;

namespace Chat_Room.Infraestructure.Chat
{
    public class ChatMessageHandler : IChatMessageHandler
    {
        private readonly ChatHub _chatHub;

        public ChatMessageHandler(ChatHub chatHub)
        {
            _chatHub = chatHub;
        }

        public async Task Handle(MessageSentEvent @event)
        {
            ChatMessage message = new ChatMessage
            {
                Content = @event.Message,
                RoomId = @event.ChatRoomId,
                UserEmail = @event.UserEmail,
                Timestamp = @event.Timestamp
            };

            await _chatHub.SendMessage(message);

            if (message.IsCommand)
            {
                Command command = CreateCommandFromMessage(message);
                if (command is StockSelectCommand)
                {
                    command.OnCommandExecuted += async (o, args) =>
                    {
                        IStockSelect stockSelect = new CsvStockSelect();
                        var stock = await stockSelect.GetStock(args.CommandParameter);
                        await _chatHub.SendMessage(new BotChatMessage(message.RoomId, stock.ToString()));
                    };
                    command.Execute();
                }
                // NOT SUPPORTED COMMAND.
                else
                {
                    await _chatHub.SendMessage(BotChatMessage.CreateUnsupportedCommandChatMessage(message.RoomId));
                }
            }
        }

        private Command CreateCommandFromMessage(ChatMessage message)
        {
            // ONLY STOCK SUPPORTED.
            if (message.Content.StartsWith("/stock"))
            {
                return new StockSelectCommand(message.Content.Substring("/stock ".Length));
            }
            else
            {
                return new BadCommand();
            }
        }
    }
}
