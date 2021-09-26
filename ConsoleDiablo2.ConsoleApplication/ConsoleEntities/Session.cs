using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.DataModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities
{
    public class Session : ISession
    {
        private Stack<IMenu> history;
        private IMenu currentMenu;
        private IServiceProvider serviceProvider;

        public Session(IServiceProvider serviceProvider)
        {
            history = new Stack<IMenu>();
            this.serviceProvider = serviceProvider;
        }

        public Account Account { get; set; }

        public Stack<IMenu> History
        {
            get { return this.history; }
            set { this.history = value; }
        }


        public IMenu CurrentMenu
        {
            get 
            {
                if (this.history.Count > 1)
                {
                    return currentMenu;
                }

                return this.history.Peek();
            }
            set { currentMenu = value; }
        }

        public IMenu Back()
        {
            IMenu menu = this.history.Peek();
            int menuId = 0;
            int round = 1;
            Monster monster = null;

            if (menu is IInfoHoldingMenu)
            {
                IInfoHoldingMenu idHoldingMenu = (IInfoHoldingMenu)menu;
                menuId = idHoldingMenu.Id;

                if (menu is IRoundHoldingMenu)
                {
                    IRoundHoldingMenu roundHoldingMenu = (IRoundHoldingMenu)idHoldingMenu;
                    round = roundHoldingMenu.Round;
                }

                if (menu is IMonsterHoldingMenu)
                {
                    IMonsterHoldingMenu monsterHoldingMenu = (IMonsterHoldingMenu)menu;
                    monster = (Monster)monsterHoldingMenu.Monster;
                }
            }

            if (menu.IsReturningMenu)
            {
                if (history.Count > 1)
                {
                    this.history.Pop();
                }

                menu = this.history.Peek();

                this.currentMenu = menu;

                menu.Open();

                return menu;
            }

            this.history.Clear();

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type menuType = assembly.GetTypes().FirstOrDefault(t => t.Name == menu.BackMenu);

            //Get the parameters that the constructor of the menu needs
            ParameterInfo[] parameters = menuType.GetConstructors().First().GetParameters();

            //Create an array of objects that are going to be taken from the service provider.
            object[] args = new object[parameters.Length];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(parameters[i].ParameterType);
            }

            //Creating an instance of the type with the given argument and returning it
            menu = (IMenu)Activator.CreateInstance(menuType, args);

            this.CurrentMenu = menu;

            if (menu is IInfoHoldingMenu)
            {
                IInfoHoldingMenu idHoldingMenu = (IInfoHoldingMenu)menu;

                if (menu is IRoundHoldingMenu)
                {
                    IRoundHoldingMenu roundHoldingMenu = (IRoundHoldingMenu)idHoldingMenu;
                    roundHoldingMenu.Round = round;

                    if (roundHoldingMenu is IMonsterHoldingMenu)
                    {
                        IMonsterHoldingMenu monsterHoldingMenu = (IMonsterHoldingMenu)roundHoldingMenu;
                        monsterHoldingMenu.Monster = monster;
                        monsterHoldingMenu.PassInformation(menuId, monster);
                    }
                }
                else
                {
                    idHoldingMenu.PassInformation(menuId);
                }
            }

            menu.Open();

            this.history.Push(menu);

            return menu;
        }

        public void LogIn(Account account)
        {
            this.Account = account;
        }

        public void LogOut()
        {
            this.Account = null;
        }

        public bool PushView(IMenu view)
        {
            if (!this.history.Any() || this.history.Peek() != view)
            {
                this.CurrentMenu = view;
                
                this.history.Push(view);

                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.Account = null;
            this.history = new Stack<IMenu>();
        }
    }
}
