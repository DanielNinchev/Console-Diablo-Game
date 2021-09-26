using ConsoleDiablo2.Common;
using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.Services.Contracts;

using System;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class SignUpCommand : IMenuCommand
    {
        private IAccountService accountService;
        private IMenuFactory menuFactory;
        private ISession session;

        public SignUpCommand(IAccountService accountService, IMenuFactory menuFactory, ISession session)
        {
            this.accountService = accountService;
            this.menuFactory = menuFactory;
            this.session = session;
        }

        public IMenu Execute(params object[] args)
        {
            string accountName = args[0].ToString();
            string password = args[1].ToString();

            bool success = accountService.TryCreatingAnAccount(accountName, password);

            Account account = accountService.GetAccountByName(accountName);

            session.Reset();
            session.LogIn(account);

            if (!success)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAccountNameOrPassword);
            }

            return menuFactory.CreateMenu(typeof(MainMenu).Name);
        }
    }
}
