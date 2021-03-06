using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.Services.Contracts;
using System.Collections.Generic;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class SelectItemCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;
        private ICharacterService characterService;

        public SelectItemCommand(IMenuFactory menuFactory, ICharacterService characterService)
        {
            this.menuFactory = menuFactory;
            this.characterService = characterService;
        }
        public IMenu Execute(params object[] args)
        {
            int itemId = (int)args[0];
            int characterId = 0;

            if (args.Length == 3)
            {
                characterId = (int)args[2];
            }

            IInfoHoldingMenu menu = (IInfoHoldingMenu)menuFactory.CreateMenu(typeof(ItemMenu).Name);

            menu.PassInformation(itemId, characterId);

            return menu;
        }
    }
}
