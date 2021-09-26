using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.Services.Contracts;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class PutItemOnCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;
        private IItemService itemService;

        public PutItemOnCommand(IMenuFactory menuFactory, IItemService itemService)
        {
            this.menuFactory = menuFactory;;
            this.itemService = itemService;
        }
        public IMenu Execute(params object[] args)
        {
            int itemId = (int)args[0];

            var item = this.itemService.GetItemById(itemId);

            int characterId = item.Inventory.CharacterId;

            this.itemService.PutItemOn(itemId, characterId);

            var menu = (IInfoHoldingMenu)menuFactory.CreateMenu(typeof(GearMenu).Name);
            menu.PassInformation(characterId);

            return menu;
        }
    }
}
