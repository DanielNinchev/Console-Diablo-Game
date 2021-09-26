using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.DataModels;

using System.Collections.Generic;

namespace ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities
{
    public interface ISession
    {
        Account Account { get; set; }

        IMenu CurrentMenu { get; set; }

        Stack<IMenu> History { get; set; }

        void LogIn(Account account);

        void LogOut();

        IMenu Back();

        bool PushView(IMenu view);

        void Reset();
    }
}
