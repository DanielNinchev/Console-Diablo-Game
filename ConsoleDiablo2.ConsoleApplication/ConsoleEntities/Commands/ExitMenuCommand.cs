using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

using System;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class ExitMenuCommand : IMenuCommand
    {
        public IMenu Execute(params object[] args)
        {
            Environment.Exit(0);
            return null;
        }
    }
}
