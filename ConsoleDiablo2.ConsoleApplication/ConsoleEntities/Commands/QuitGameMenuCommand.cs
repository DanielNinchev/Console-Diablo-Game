using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.Services.Contracts;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class QuitGameMenuCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;
        private ICharacterService characterService;

        public QuitGameMenuCommand(IMenuFactory menuFactory, ICharacterService characterService)
        {
            this.menuFactory = menuFactory;
            this.characterService = characterService;
        }
        public IMenu Execute(params object[] args)
        {
            int characterId = (int)args[0];

            this.characterService.Recover(characterId);

            IInfoHoldingMenu menu = (IInfoHoldingMenu)this.menuFactory.CreateMenu(typeof(CreateCharacterMenu).Name);

            menu.PassInformation(characterId);

            return menu;
        }
    }
}
