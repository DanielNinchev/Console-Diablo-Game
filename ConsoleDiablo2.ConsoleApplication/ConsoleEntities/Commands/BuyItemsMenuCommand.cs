using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.Services.Contracts;
using System.Collections.Generic;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class BuyItemsMenuCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;
        private IItemService itemService;

        public BuyItemsMenuCommand(IMenuFactory menuFactory, IItemService itemService)
        {
            this.menuFactory = menuFactory;
            this.itemService = itemService;
        }
        public IMenu Execute(params object[] args)
        {
            int characterId = (int)args[0];
            string command = args[1].ToString();

            List<int> itemIds = this.itemService.GenerateShopItemsForCharacter(characterId, command);

            IInfoHoldingMenu menu = (IInfoHoldingMenu)this.menuFactory.CreateMenu(typeof(ShopItemsMenu).Name);

            menu.PassInformation(characterId, itemIds);

            return menu;
        }
    }
}
