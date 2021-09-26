using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.Services.Contracts;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class DeleteCharacterMenuCommand : IMenuCommand
    {
        private ISession session;
        private ICharacterService characterService;
        private IMenuFactory menuFactory;

        public DeleteCharacterMenuCommand(ISession session, ICharacterService characterService, IMenuFactory menuFactory)
        {
            this.session = session;
            this.characterService = characterService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params object[] args)
        {
            int characterId = (int)args[0];

            this.characterService.DeleteCharacter(characterId);

            IInfoHoldingMenu menu = (IInfoHoldingMenu)this.menuFactory.CreateMenu(typeof(ChooseAnExistingCharacterMenu).Name);

            menu.PassInformation(this.session.Account.Id);

            return menu;
        }
    }
}
