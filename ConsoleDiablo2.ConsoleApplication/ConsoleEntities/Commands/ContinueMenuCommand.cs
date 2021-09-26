using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.Services.Contracts;
using System.Linq;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class ContinueMenuCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;
        private ICharacterService characterService;
        private IItemService itemService;

        public ContinueMenuCommand(IMenuFactory menuFactory, ICharacterService characterService, IItemService itemService)
        {
            this.menuFactory = menuFactory;
            this.characterService = characterService;
            this.itemService = itemService;
        }

        public IMenu Execute(params object[] args)
        {
            int characterId = (int)args[0];
            Monster monster = (Monster)args[1];
            string skillName = args[2].ToString();

            IInfoHoldingMenu menu = (IInfoHoldingMenu)menuFactory.CreateMenu(typeof(ContinueMenu).Name);

            var character = (Character)this.characterService.GetCharacterById(characterId);

            this.characterService.Recover(characterId);

            int itemId = itemService.DropPrize(monster.Type);

            menu.PassInformation(characterId, itemId, monster);

            return menu;
        }
    }
}
