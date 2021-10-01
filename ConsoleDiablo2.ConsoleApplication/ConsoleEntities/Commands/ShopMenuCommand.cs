using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class ShopMenuCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;

        public ShopMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }
        public IMenu Execute(params object[] args)
        {
            int itemId = (int)args[0];

            IInfoHoldingMenu menu = (IInfoHoldingMenu)menuFactory.CreateMenu(typeof(ShopMenu).Name);

            menu.PassInformation(itemId);

            return menu;
        }
    }
}
