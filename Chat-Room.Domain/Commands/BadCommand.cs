namespace Chat_Room.Domain.Commands
{
    public class BadCommand : Command
    {
        protected BadCommand(string value, string parameter) : base(value, parameter)
        {
        }

        public BadCommand() : base("BAD COMMAND", string.Empty)
        {
        }
    }
}
