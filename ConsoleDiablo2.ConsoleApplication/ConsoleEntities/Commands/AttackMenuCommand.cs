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
    public class AttackMenuCommand : IMenuCommand
    {
        private IMenuFactory menuFactory;
        private ICharacterService characterService;
        private IMonsterService monsterService;

        public AttackMenuCommand(IMenuFactory menuFactory, ICharacterService characterService, IMonsterService monsterService)
        {
            this.menuFactory = menuFactory;
            this.characterService = characterService;
            this.monsterService = monsterService;
        }
        public IMenu Execute(params object[] args)
        {
            int characterId = (int)args[0];
            Monster monster = (Monster)args[1];
            string chosenSkill = args[2].ToString();
            int round = (int)args[3];

            var character = (Character)characterService.GetCharacterById(characterId);
            var skill = character.Skills.FirstOrDefault(s => s.Name == chosenSkill);

            foreach (var auraSkill in character.Skills.Where(a => a.IsActivated && a is IAura))
            {
                IAura aura = (IAura)auraSkill;

                aura.DeactivateSkill(round, character);
            }

            foreach (IEnemyAffectingSkill enemyAffectingSkill in character.Skills.Where(e => e.IsActivated && !(e is IAura) && e is IEnemyAffectingSkill))
            {
                enemyAffectingSkill.UnaffectEnemy(monster);
            }

            foreach (var activeSkill in character.Skills.Where(s => s.IsActivated && !(s is IAura)))
            {
                activeSkill.UnaffectCharacter(character);
            }

            if (skill != null)
            {
                skill.IsActivated = true;
                skill.AffectCharacter(character);
            }

            this.monsterService.FightMonster(characterId, monster, skill);

            IMonsterHoldingMenu menu = (IMonsterHoldingMenu)this.menuFactory.CreateMenu(typeof(FightMonsterMenu).Name);

            round++;

            menu.PassInformation(characterId, monster, chosenSkill, round);

            return menu;
        }
    }
}
