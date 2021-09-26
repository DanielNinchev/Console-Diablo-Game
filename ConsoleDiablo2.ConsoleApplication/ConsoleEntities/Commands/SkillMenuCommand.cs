using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    class SkillMenuCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;

        public SkillMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }
        public IMenu Execute(params object[] args)
        {
            int characterId = (int)args[0];
            string chosenSkill = args[1].ToString();

            ISkillHoldingMenu menu = (ISkillHoldingMenu)this.menuFactory.CreateMenu(typeof(SelectSkillMenu).Name);

            menu.PassInformation(characterId, chosenSkill);

            return menu;
        }
    }
}
