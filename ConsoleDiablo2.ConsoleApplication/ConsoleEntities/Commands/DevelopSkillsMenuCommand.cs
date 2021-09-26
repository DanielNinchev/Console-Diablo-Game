using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class DevelopSkillsMenuCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;

        public DevelopSkillsMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }
        public IMenu Execute(params object[] args)
        {
            int characterId = (int)args[0];

            ISkillHoldingMenu menu = (ISkillHoldingMenu)this.menuFactory.CreateMenu(typeof(DevelopSkillsMenu).Name);

            menu.PassInformation(characterId);

            return menu;
        }
    }
}
