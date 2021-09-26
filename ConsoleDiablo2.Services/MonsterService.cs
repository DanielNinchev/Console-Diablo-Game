using ConsoleDiablo2.Common;
using ConsoleDiablo2.Data;
using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.DataModels.Factories.Contracts;
using ConsoleDiablo2.Services.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDiablo2.Services
{
    public class MonsterService : IMonsterService
    {
        private ConsoleDiabloDbContext db;
        private ICharacterService characterService;
        private IItemService itemService;
        private IMonsterFactory monsterFactory;

        public MonsterService(ConsoleDiabloDbContext db, ICharacterService characterService,
            IItemService itemService, IMonsterFactory monsterFactory)
        {
            this.db = db;
            this.characterService = characterService;
            this.itemService = itemService;
            this.monsterFactory = monsterFactory;
        }

        public void AttackCharacter(int characterId, Monster monster)
        {
            var character = (Character)characterService.GetCharacterById(characterId);

            monster.Attack(character);

            if (character.Life <= 0)
            {
                this.characterService.KillCharacter(characterId);
            }
            else
            {
                this.characterService.Regenerate(characterId);
            }

            this.db.SaveChanges();
        }

        public Monster CreateMonster(int characterId)
        {
            var character = (Character)characterService.GetCharacterById(characterId);
            var monsterType = DrawMonsterType();

            Monster monster = monsterFactory.CreateMonster(monsterType, character);

            return monster;
        }

        public string DrawMonsterType()
        {
            Random random = new Random();

            List<string> monsters = itemService.GetListOfSubclasses<Monster>();

            itemService.ShuffleAList(monsters, random);

            string typeOfmonster = monsters[random.Next(0, monsters.Count())];

            return typeOfmonster;
        }

        public void FightMonster(int characterId, Monster monster, Skill skill)
        {
            bool monsterIsAlive = this.SufferAttack(characterId, monster, skill);

            if (monsterIsAlive)
            {
                this.AttackCharacter(characterId, monster);
            }
            else
            {
                var character = (Character)this.characterService.GetCharacterById(characterId);

                monster.UnaffectCharacter(character);
                this.characterService.LevelUp(characterId);
            }
        }

        public bool SufferAttack(int characterId, Monster monster, Skill skill)
        {
            var character = (Character)characterService.GetCharacterById(characterId);

            if (character != null)
            {
                int takenDamage = this.characterService.Attack(character, monster, skill);

                monster.Life -= takenDamage;

                if (monster.Life <= 0)
                {
                    monster.Life = 0;
                    monster.IsAlive = false;

                    character.Experience += (int)monster.Type * MonsterConstants.ExperienceGivenFromMonster;
                }
            }

            return monster.IsAlive;
        }
    }
}
