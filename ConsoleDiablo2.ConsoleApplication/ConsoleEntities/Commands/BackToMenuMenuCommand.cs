using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.Services.Contracts;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class BackToMenuMenuCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;
        private ICharacterService characterService;
        private IItemService itemService;

        public BackToMenuMenuCommand(IMenuFactory menuFactory, ICharacterService characterService, IItemService itemService)
        {
            this.menuFactory = menuFactory;
            this.characterService = characterService;
            this.itemService = itemService;
        }
        public IMenu Execute(params object[] args)
        {
            int characterId = (int)args[0];
            int itemId = (int)args[1];
            Monster monster = (Monster)args[2];
            bool itemHasBeenPicked = (bool)args[3];

            if (!itemHasBeenPicked)
            {
                this.itemService.DeleteItemFromDb(itemId);
            }

            monster.UnaffectCharacter((Character)this.characterService.GetCharacterById(characterId));

            this.characterService.Recover(characterId);

            IInfoHoldingMenu menu = (IInfoHoldingMenu)this.menuFactory.CreateMenu(typeof(CreateCharacterMenu).Name);

            menu.PassInformation(characterId);

            return menu;
        }
    }
}
