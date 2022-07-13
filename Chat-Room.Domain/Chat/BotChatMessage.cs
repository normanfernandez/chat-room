namespace Chat_Room.Domain.Chat
{
    public class BotChatMessage : ChatMessage
    {
        public const int BOT_USER_ID = -1;
        public const string UNSUPPORTED_COMMAND_MESSAGE = "COMMAND NOT SUPPORTED";

        public BotChatMessage(int roomId, string message)
        {
            this.Content = message;
            this.RoomId = roomId;
            this.UserId = BOT_USER_ID;
        }

        public static BotChatMessage CreateUnsupportedCommandChatMessage(int roomId)
        {
            return new BotChatMessage(roomId, UNSUPPORTED_COMMAND_MESSAGE);
        }
    }
}
