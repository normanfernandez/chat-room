namespace Chat_Room.Domain.Chat
{
    public class BotChatMessage : ChatMessage
    {
        public const string BOT_USER_ID = "BOT-KUN";
        public const string UNSUPPORTED_COMMAND_MESSAGE = "COMMAND NOT SUPPORTED";

        public BotChatMessage(int roomId, string message)
        {
            this.Content = message;
            this.RoomId = roomId;
            this.UserEmail = BOT_USER_ID;
        }

        public static BotChatMessage CreateUnsupportedCommandChatMessage(int roomId)
        {
            return new BotChatMessage(roomId, UNSUPPORTED_COMMAND_MESSAGE);
        }
    }
}
