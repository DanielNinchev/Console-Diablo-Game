using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.Services.Contracts;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class ChooseAnExistingCharacterMenuCommand : IMenuCommand
    {
        private ISession session;
        private IMenuFactory menuFactory;
        private IAccountService accountService;
        private ICharacterService characterService;

        public ChooseAnExistingCharacterMenuCommand(ISession session, IMenuFactory menuFactory,
            IAccountService accountService, ICharacterService characterService)
        {
            this.session = session;
            this.menuFactory = menuFactory;
            this.accountService = accountService;
            this.characterService = characterService;
        }

        public IMenu Execute(params object[] args)
        {
            var account = this.accountService.GetAccountById(this.session.Account.Id);

            if (account.Characters.Count > 0)
            {
                foreach (var character in account.Characters)
                {
                    this.characterService.LoadCharacterInfoFromDbByHisId(character.Id);
                }
            }

            string menuName = typeof(ChooseAnExistingCharacterMenu).Name;

            IInfoHoldingMenu menu = (IInfoHoldingMenu)this.menuFactory.CreateMenu(menuName);
            menu.PassInformation(account.Id);

            return menu;
        }
    }
}
