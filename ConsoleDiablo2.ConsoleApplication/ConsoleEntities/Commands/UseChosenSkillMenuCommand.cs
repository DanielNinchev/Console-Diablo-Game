using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.DataModels;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class UseChosenSkillMenuCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;

        public UseChosenSkillMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }
        public IMenu Execute(params object[] args)
        {
            int characterId = (int)args[0];
            Monster monster = (Monster)args[1];
            string chosenSkill = args[2].ToString();
            int round = (int)args[3];

            IMonsterHoldingMenu menu = (IMonsterHoldingMenu)this.menuFactory.CreateMenu(typeof(FightMonsterMenu).Name);

            menu.PassInformation(characterId, monster, chosenSkill, round);

            return menu;
        }
    }
}
