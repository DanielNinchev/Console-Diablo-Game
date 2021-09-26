using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class SelectCharacterTypeCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;

        public SelectCharacterTypeCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }
        public IMenu Execute(params object[] args)
        {
            return menuFactory.CreateMenu(typeof(SelectCharacterTypeMenu).Name);
        }
    }
}
