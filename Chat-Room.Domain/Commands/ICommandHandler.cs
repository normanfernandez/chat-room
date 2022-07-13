using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Room.Domain.Commands
{
    public interface ICommandHandler
    {
        Command RetreiveCommand(string content);
    }
}
