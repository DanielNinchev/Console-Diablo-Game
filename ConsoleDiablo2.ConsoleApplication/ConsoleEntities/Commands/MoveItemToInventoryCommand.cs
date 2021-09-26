using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.Services.Contracts;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class MoveItemToInventoryCommand : IMenuCommand
    {
        private IItemService itemService;
        private IMenuFactory menuFactory;

        public MoveItemToInventoryCommand(IItemService itemService, IMenuFactory menuFactory)
        {
            this.itemService = itemService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params object[] args)
        {
            int itemId = (int)args[0];
            var item = itemService.GetItemById(itemId);

            itemService.MoveItemToInventory(itemId, item.Gear.CharacterId);

            IInfoHoldingMenu menu = (IInfoHoldingMenu)menuFactory.CreateMenu(typeof(GearMenu).Name);

            menu.PassInformation(item.InventoryId);

            return menu;
        }
    }
}
