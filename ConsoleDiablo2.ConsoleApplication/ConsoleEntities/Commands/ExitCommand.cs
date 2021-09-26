using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

using System;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class ExitCommand : IMenuCommand
    {
        public IMenu Execute(params object[] args)
        {
            Environment.Exit(-1);

            return null;
        }
    }
}
