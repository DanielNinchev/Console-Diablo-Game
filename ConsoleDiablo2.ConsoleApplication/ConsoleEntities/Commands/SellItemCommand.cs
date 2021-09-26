using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.Services.Contracts;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class SellItemCommand : IMenuCommand
    {
        private IItemService itemService;
        private IMenuFactory menuFactory;

        public SellItemCommand(IItemService itemService, IMenuFactory menuFactory)
        {
            this.itemService = itemService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params object[] args)
        {
            int itemId = (int)args[0];

            var item = this.itemService.GetItemById(itemId);

            var characterId = (item.Gear == null) ? item.Inventory.CharacterId : item.Gear.CharacterId;

            this.itemService.SellItem(itemId, characterId);

            var menu = (IInfoHoldingMenu)menuFactory.CreateMenu(typeof(CreateCharacterMenu).Name);

            menu.PassInformation(characterId);

            return menu;
        }
    }
}
