using System;

namespace Chat_Room.Domain.Commands.Events
{
    public class CommandExecutedEvent : EventArgs
    {
        public DateTime Timestamp { get; } = DateTime.Now;
        public string CommandName { get; private set; }
        public string CommandParameter { get; private set; }

        public CommandExecutedEvent(string commandName, string commandParameter)
        {
            CommandName = commandName;
            CommandParameter = commandParameter;
        }
    }
}
