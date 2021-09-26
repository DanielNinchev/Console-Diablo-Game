using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class MultiplayerMenuCommand : MenuCommand
    {
        public MultiplayerMenuCommand(IMenuFactory menuFactory) : base(menuFactory)
        {
        }
    }
}
