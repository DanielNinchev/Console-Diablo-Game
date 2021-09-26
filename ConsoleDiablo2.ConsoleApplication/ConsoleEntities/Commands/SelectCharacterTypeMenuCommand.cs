using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class SelectCharacterTypeMenuCommand : MenuCommand
    {
        public SelectCharacterTypeMenuCommand(IMenuFactory menuFactory) : base(menuFactory)
        {
        }
    }
}
