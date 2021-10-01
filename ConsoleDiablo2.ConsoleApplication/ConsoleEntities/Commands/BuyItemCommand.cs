using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.Services.Contracts;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class BuyItemCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;
        private IItemService itemService;

        public BuyItemCommand(IMenuFactory menuFactory, IItemService itemService)
        {
            this.menuFactory = menuFactory;
            this.itemService = itemService;
        }
        public IMenu Execute(params object[] args)
        {
            int itemId = (int)args[0];
            int characterId = (int)args[1];

            this.itemService.BuyItemsWithCharacter(characterId, itemId);

            IInfoHoldingMenu menu = (IInfoHoldingMenu)this.menuFactory.CreateMenu(typeof(InventoryMenu).Name);

            menu.PassInformation(characterId);

            return menu;
        }
    }
}
