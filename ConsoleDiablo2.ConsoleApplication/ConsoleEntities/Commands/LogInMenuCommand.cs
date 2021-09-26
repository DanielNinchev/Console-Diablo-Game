using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class LogInMenuCommand : MenuCommand
    {
        public LogInMenuCommand(IMenuFactory menuFactory) : base(menuFactory)
        {
        }
    }
}
