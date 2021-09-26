using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class ExitMenuCommand : MenuCommand
    {
        public ExitMenuCommand(IMenuFactory menuFactory) : base(menuFactory)
        {
        }
    }
}
