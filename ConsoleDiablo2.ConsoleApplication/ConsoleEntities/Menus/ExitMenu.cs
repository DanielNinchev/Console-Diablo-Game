using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

using System;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus
{
    public class ExitMenu : Menu
    {
        public override IMenu ExecuteCommand()
        {
            Environment.Exit(-1);

            return null;
        }

        protected override void InitializeButtons(Position consoleCenter)
        {
            
        }

        protected override void InitializeStaticLabels(Position consoleCenter)
        {
           
        }
    }
}
