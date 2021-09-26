﻿using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class GearMenuCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;

        public GearMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params object[] args)
        {
            int characterId = (int)args[0];

            IInfoHoldingMenu menu = (IInfoHoldingMenu)this.menuFactory.CreateMenu(typeof(GearMenu).Name);
            menu.PassInformation(characterId);

            return menu;
        }
    }
}
