using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class LogOutMenuCommand : MenuCommand
    {
        public LogOutMenuCommand(IMenuFactory menuFactory) : base(menuFactory)
        {
        }
    }
}
