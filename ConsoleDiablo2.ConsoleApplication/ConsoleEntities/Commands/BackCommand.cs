using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class BackCommand : IMenuCommand
    {
        private readonly ISession session;

        public BackCommand(ISession session)
        {
            this.session = session;
        }
        public IMenu Execute(params object[] args)
        {
            IMenu menu = this.session.Back();

            return menu;
        }
    }
}
