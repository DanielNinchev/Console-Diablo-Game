using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

using ConsoleDiablo2.Services.Contracts;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class FightMonsterMenuCommand : IMenuCommand
    {
        private ISession session;
        private IMenuFactory menuFactory;
        private ICharacterService characterService;

        public FightMonsterMenuCommand(ISession session, IMenuFactory menuFactory, ICharacterService characterService)
        {
            this.session = session;
            this.menuFactory = menuFactory;
            this.characterService = characterService;
        }

        public IMenu Execute(params object[] args)
        {
            var currentMenu = (IInfoHoldingMenu)this.session.CurrentMenu;

            int characterId = currentMenu.Id;

            this.characterService.Recover(characterId);

            string menuName = typeof(FightMonsterMenu).Name;

            IInfoHoldingMenu menu = (IInfoHoldingMenu)this.menuFactory.CreateMenu(menuName);
            menu.PassInformation(characterId);

            return menu;
        }
    }
}
