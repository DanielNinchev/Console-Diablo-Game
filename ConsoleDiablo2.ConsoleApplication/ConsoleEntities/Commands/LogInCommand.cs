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
    public class LogInCommand : IMenuCommand
    {
        private IAccountService accountService;
        private IMenuFactory menuFactory;
        private ISession session;

        public LogInCommand(IAccountService accountService, IMenuFactory menuFactory, ISession session)
        {
            this.accountService = accountService;
            this.menuFactory = menuFactory;
            this.session = session;
        }

        public IMenu Execute(params object[] args)  
         {
            var accountName = args[0].ToString();
            var password = args[1].ToString();

            bool success = this.accountService.TryLoggingIn(accountName, password);

            Account account = this.accountService.GetAccountByName(accountName);

            this.session.Reset();
            this.session.LogIn(account);

            if (!success)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAccountNameOrPassword);
            }

            return this.menuFactory.CreateMenu(typeof(MainMenu).Name);
        }
    }
}
