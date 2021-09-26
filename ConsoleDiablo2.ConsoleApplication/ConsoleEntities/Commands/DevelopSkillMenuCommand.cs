using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.Services.Contracts;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class DevelopSkillMenuCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;
        private ICharacterService characterService;

        public DevelopSkillMenuCommand(IMenuFactory menuFactory, ICharacterService characterService)
        {
            this.menuFactory = menuFactory;
            this.characterService = characterService;
        }
        public IMenu Execute(params object[] args)
        {
            int characterId = (int)args[0];
            string chosenSkill = args[1].ToString().TrimEnd();

            this.characterService.DevelopSkill(characterId, chosenSkill);

            ISkillHoldingMenu menu = (ISkillHoldingMenu)this.menuFactory.CreateMenu(typeof(DevelopSkillsMenu).Name);

            menu.PassInformation(characterId, chosenSkill);

            return menu;
        }
    }
}
