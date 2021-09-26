using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.Services.Contracts;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class CreateCharacterCommand : IMenuCommand
    {
        private ISession session;
        private ICharacterService characterService;
        private IItemService itemService;
        private IMenuFactory menuFactory;

        public CreateCharacterCommand(ISession session, ICharacterService characterService, IItemService itemService, IMenuFactory menuFactory)
        {
            this.session = session;
            this.characterService = characterService;
            this.itemService = itemService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params object[] args)
        {
            int accountId = this.session.Account.Id;

            string characterName = args[0].ToString();
            string characterType = args[1].ToString();

            int characterId = this.characterService.CreateNewCharacter(accountId, characterName, characterType);

            this.characterService.InitializeCharacterSkills(characterId);

            //this.itemService.GiveCharacterHisBasicGear(characterId);

            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, (commandName.Length - "Command".Length)) + "Menu";

            IInfoHoldingMenu menu = (IInfoHoldingMenu)this.menuFactory.CreateMenu(menuName);
            menu.PassInformation(characterId);

            return menu;
        }
    }
}
