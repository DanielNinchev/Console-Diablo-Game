using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class SinglePlayerMenuCommand : MenuCommand
    {
        public SinglePlayerMenuCommand(IMenuFactory menuFactory) : base(menuFactory)
        {
        }
    }
}
