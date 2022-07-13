using Chat_Room.Domain.Commands.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Room.Domain.Commands
{
    public class Command
    {
        public event EventHandler<CommandExecutedEvent> OnCommandExecuted;
        public string Value { get; private set; }
        public string Parameter { get; private set; }

        protected Command(string value, string parameter)
        {
            Value = value;
            Parameter = parameter;
        }

        public virtual Task Execute()
        {
            try
            {
                OnCommandExecuted?.Invoke(this, CreateCommandExecutedEvent());
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.CompletedTask;
            }
        }

        private CommandExecutedEvent CreateCommandExecutedEvent() =>
            new CommandExecutedEvent(Value, Parameter);
    }
}
