using System.Collections.Generic;

namespace ConsoleDiablo2.Services.Contracts
{
    public interface ICommandService
    {
        string ProcessCommand(string commandName, IList<string> commandArgs);
    }
}
