using ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Menus;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Factories;
using ConsoleDiablo2.ConsoleApplication.Contracts.ConsoleEntities.Menus;
using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.DataModels.Skills.Contracts;
using ConsoleDiablo2.Services.Contracts;
using System.Linq;

namespace ConsoleDiablo2.ConsoleApplication.ConsoleEntities.Commands
{
    public class MeleeAttackMenuCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;
        private ICharacterService characterService;
        private IMonsterService monsterService;

        public MeleeAttackMenuCommand(IMenuFactory menuFactory, ICharacterService characterService, IMonsterService monsterService)
        {
            this.menuFactory = menuFactory;
            this.characterService = characterService;
            this.monsterService = monsterService;
        }

        public IMenu Execute(params object[] args)
        {
            int characterId = (int)args[0];
            Monster monster = (Monster)args[1];
            string skillName = args[2].ToString();
            int round = (int)args[3];

            var character = (Character)this.characterService.GetCharacterById(characterId);
            var skill = character.Skills.FirstOrDefault(s => s.Name == skillName);

            this.monsterService.FightMonster(characterId, monster, skill);

            IInfoHoldingMenu menu = (FightMonsterMenu)menuFactory.CreateMenu(typeof(FightMonsterMenu).Name);

            menu.PassInformation(characterId, monster, skillName, round++);

            return menu;
        }
    }
}
