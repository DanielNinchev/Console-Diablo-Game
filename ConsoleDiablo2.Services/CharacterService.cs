using ConsoleDiablo2.Common;
using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.Data;
using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.DataModels.Characters.Contracts;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Factories.Contracts;
using ConsoleDiablo2.DataModels.Items.DefensiveItems;
using ConsoleDiablo2.DataModels.Items.Weapons;
using ConsoleDiablo2.DataModels.Skills.Contracts;
using ConsoleDiablo2.Services.Contracts;
using ConsoleDiablo2.Services.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleDiablo2.Services
{
    public class CharacterService : ICharacterService
    {
        private ConsoleDiabloDbContext db;
        private IAccountService accountService;
        private ICharacterFactory characterFactory;
        private ISkillFactory skillFactory;

        public CharacterService(ConsoleDiabloDbContext db, IAccountService accountService, ICharacterFactory characterFactory,
            ISkillFactory skillFactory)
        {
            this.db = db;
            this.accountService = accountService;
            this.characterFactory = characterFactory;
            this.skillFactory = skillFactory;
        }

        public int Attack(params object[] parameters)
        {
            Character character = (Character)parameters[0];
            Being enemy = (Being)parameters[1];
            Skill skill = (Skill)parameters[2];

            if (character != null && enemy != null && skill != null)
            {
                if (skill is IEnemyAffectingSkill)
                {
                    IEnemyAffectingSkill enemyAffectingSkill = (IEnemyAffectingSkill)skill;
                    enemyAffectingSkill.AffectEnemy(enemy);
                }
            }

            double damageDone = character.Damage;

            switch (character.DamageType)
            {
                case DamageType.Fire:
                    damageDone *= Math.Max(1 - enemy.FireResistance / GlobalConstants.ResistanceDivider, 0);
                    break;
                case DamageType.Cold:
                    damageDone *= Math.Max(1 - enemy.ColdResistance / GlobalConstants.ResistanceDivider, 0);
                    break;
                case DamageType.Lightning:
                    damageDone *= Math.Max(1 - enemy.LightningResistance / GlobalConstants.ResistanceDivider, 0);
                    break;
                case DamageType.Poison:
                    damageDone *= Math.Max(1 - enemy.PoisonResistance / GlobalConstants.ResistanceDivider, 0);
                    enemy.LifeRegenerator = 0;
                    break;
                case DamageType.Physical:
                    damageDone -= enemy.Defense / GlobalConstants.DefenseDivider;
                    break;
            }

            Random random = new Random();

            if (enemy != null && character.IsAlive && enemy.IsAlive)
            {
                int chanceOfCriticalHit = random.Next(1, BonusConstants.MaxChanceOfCriticalHit);

                foreach (Weapon item in character.Gear.Items.Where(i => i.GetType().IsSubclassOf(typeof(Weapon))))
                {
                    if (item.IgnoreTargetsDefense)
                    {
                        damageDone += enemy.Defense / GlobalConstants.DefenseDivider;
                    }

                    if (item.DamageToMonsterType != null && item.DamageToMonsterType.Description.Contains(enemy.GetType().Name))
                    {
                        damageDone *= (1 + (item.DamageToMonsterType.Value / 100));
                    }
                }

                if (chanceOfCriticalHit <= character.ChanceOfCriticalHit)
                {
                    damageDone += damageDone;
                }
            }

            return Math.Max((int)damageDone, 0);
        }

        public int GetCharacterIdByHisName(string characterName)
        {
            ICharacter character = this.db.Characters.FirstOrDefault(h => h.Name.Equals(characterName));

            if (character == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterDoesNotExist);
            }

            return character.Id;
        }

        public int CreateNewCharacter(int accountId, string characterName, string characterType)
        {
            bool validCharacterName = !string.IsNullOrEmpty(characterName) && characterName.Length > 2 && characterName.Length <= GlobalConstants.CharacterNameMaxValue;

            if (!validCharacterName)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNameTooShort, characterName));
            }

            foreach (var symbol in GlobalConstants.characterNameForbiddenSymbols)
            {
                if (characterName.Contains(symbol))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCharacterName);
                }
            }

            bool characterAlreadyExists = this.db.Characters.Any(ch => ch.Name.Equals(characterName));

            if (characterAlreadyExists)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNameTaken);
            }

            if (characterType == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            Account owner = this.accountService.GetAccountById(accountId);

            Character character = this.characterFactory.CreateCharacter(characterType, characterName);

            Gear gear = new Gear();
            Inventory inventory = new Inventory();

            character.Gear = gear;
            character.GearId = gear.Id;

            character.Inventory = inventory;
            character.InventoryId = inventory.Id;

            this.db.Characters.Add(character);
            this.db.Gears.Add(gear);
            this.db.Inventories.Add(inventory);

            owner.Characters.Add(character);

            this.db.SaveChanges();

            return character.Id;
        }

        public void DeleteCharacter(int characterId)
        {
            var character = (Character)GetCharacterById(characterId);

            var account = this.accountService.GetAccountById(character.AccountId);

            account.Characters.Remove(character);

            character.IsDeleted = true;
            character.Skills.Clear();

            var removedSkills = new List<Skill>();

            foreach (var skill in this.db.Skills.Where(s => s.CharacterId == characterId))
            {
                removedSkills.Add(skill);
            }

            this.db.Skills.RemoveRange(removedSkills);

            this.db.SaveChanges();
        }

        public void DevelopSkill(int characterId, string chosenSkill)
        {
            var character = (Character)this.GetCharacterById(characterId);
            var selectedSkill = this.GetCharacterSkillByItsName(character, chosenSkill);

            if (character != null && character.SkillPoints > 0 && selectedSkill != null)
            {
                foreach (var skill in character.Skills)
                {
                    if ((selectedSkill.RequiredSkill.Equals(skill.Name) && skill.IsDeveloped) ||
                        (selectedSkill.RequiredSkill == SkillDescriptions.NoRequiredSkill && selectedSkill == skill))
                    {
                        if (selectedSkill.RequiredLevel <= character.Level)
                        {
                            selectedSkill.IsDeveloped = true;
                            selectedSkill.Level++;
                            character.SkillPoints--;

                            if (selectedSkill.IsPassive)
                            {
                                selectedSkill.IsActivated = true;
                                selectedSkill.AffectCharacter(character);
                            }
                        }
                        else
                        {
                            throw new ArgumentException(ExceptionMessages.NotExperiencedEnoughForThisSkillMsg);
                        }

                        break;
                    }
                    else if (selectedSkill.RequiredSkill.Equals(skill.Name) && !skill.IsDeveloped)
                    {
                        throw new ArgumentException(string.Format(ExceptionMessages.ParentSkillNotDeveloped, selectedSkill.RequiredSkill));
                    }
                }
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.NoSkillPointsLeft);
            }

            this.db.SaveChanges();
        }

        public void DevelopStats(int characterId, string chosenStat)
        {
            var character = (Character)this.GetCharacterById(characterId);

            if (character.StatusPoints > 0)
            {
                switch (chosenStat)
                {
                    case CharacterConstants.StrengthStatName:
                        character.Damage = (int)(character.Damage * CharacterConstants.StrengthStatMultiplier);
                        break;
                    case CharacterConstants.DexterityStatName:
                        character.ChanceOfCriticalHit += CharacterConstants.DexterityChanceOfCriticalHitValue;
                        character.ChanceToBlock += CharacterConstants.DexterityChanceToBlockValue;
                        character.Defense += CharacterConstants.DexterityDefenseValue;
                        break;
                    case CharacterConstants.VitalityStatName:
                        character.BaseLife = (int)(character.BaseLife * CharacterConstants.VitalityLifeMultiplier);
                        character.Life = character.BaseLife;
                        character.LifeRegenerator *= CharacterConstants.VitalityLifeMultiplier;
                        break;
                    case CharacterConstants.EnergyStatName:
                        character.BaseMana = (int)(character.BaseMana * CharacterConstants.EnergyManaMultiplier);
                        character.Mana = character.BaseMana;
                        character.ManaRegenerator *= CharacterConstants.EnergyManaMultiplier;
                        break;
                }

                character.StatusPoints--;
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.NoStatPointsLeft);
            }

            this.db.SaveChanges();
        }

        public ICharacter GetCharacterById(int characterId)
        {
            var character = this.db.Characters.FirstOrDefault(ch => ch.Id == characterId);

            return character;
        }

        public Skill GetCharacterSkillByItsName(Character character, string skillName)
        {
            var skill = character.Skills.FirstOrDefault(s => s.Name == skillName);

            return skill;
        }

        public void InitializeCharacterSkills(int characterId)
        {
            var character = this.GetCharacterById(characterId);

            foreach (var skillName in character.SkillTree.GetRootNamesInAList())
            {
                var skill = this.skillFactory.CreateSkill(skillName);

                character.Skills.Add(skill);
            }

            this.db.SaveChanges();
        }

        public void LoadCharacterInfoFromDbByHisId(int characterId)
        {
            var character = this.GetCharacterById(characterId);

            character.Gear = this.db.Gears.FirstOrDefault(g => g.Id == character.GearId);
            character.Gear.Items = this.db.Items.Where(i => i.GearId == character.Gear.Id).ToHashSet();
            character.Gear.CharacterId = characterId;

            character.Inventory = this.db.Inventories.FirstOrDefault(i => i.Id == character.InventoryId);
            character.Inventory.Items = this.db.Items.Where(i => i.InventoryId == character.Inventory.Id).ToHashSet();
            character.Inventory.CharacterId = characterId;

            var characterSkills = this.db.Skills.Where(s => s.CharacterId == characterId);

            foreach (var skill in characterSkills)
            {
                character.Skills.Add(skill);
            }

            this.LoadCharactersItemsBonuses(character.Gear.Items);
            this.LoadCharactersItemsBonuses(character.Inventory.Items);

            this.db.SaveChanges();
        }

        public void LoadCharactersItemsBonuses(ICollection<Item> itemCollection)
        {
            foreach (var item in itemCollection)
            {
                foreach (var bonus in this.db.Bonuses.Where(b => b.ItemId == item.Id))
                {
                    item.Bonuses.Add(bonus);
                }

                if (item.GetType().IsSubclassOf(typeof(Weapon)))
                {
                    Weapon weapon = (Weapon)item;

                    weapon.LoadWeaponBonuses();
                }
                else
                {
                    DefensiveEquipment defItem = (DefensiveEquipment)item;

                    defItem.LoadDefensiveEquipmentBonuses();
                }
            }
        }

        public void KillCharacter(int characterId)
        {
            var character = (Character)GetCharacterById(characterId);

            character.Experience = character.Level * 1000;

            character.IsAlive = false;

            foreach (var skill in character.Skills.Where(s => s.IsActivated))
            {
                skill.UnaffectCharacter(character);
            }
        }

        public void LevelUp(int characterId)
        {
            var character = GetCharacterById(characterId);

            if (character.Level < character.Experience / 1000)
            {
                character.HasLeveledUp = true;
                character.Level += 1;
                character.SkillPoints += 1;
                character.StatusPoints += 1;
            }
        }

        public void Recover(int characterId)
        {
            var character = (Character)GetCharacterById(characterId);

            character.IsAlive = true;

            this.UnaffectCharacterWithEachActiveSkill(character);

            character.Life = character.BaseLife;
            character.Mana = character.BaseMana;

            this.db.SaveChanges();
        }

        public void Regenerate(int characterId)
        {
            var character = (Character)GetCharacterById(characterId);

            if (!character.IsPoisoned)
            {
                character.LifeRegenerator = CharacterConstants.LifeRegenerator;
            }

            if (!character.IsFrozen)
            {
                character.ManaRegenerator = CharacterConstants.ManaRegenerator;
            }

            character.Life = Math.Min(character.Life + character.BaseLife * character.LifeRegenerator, character.BaseLife);
            character.Mana = Math.Min(character.Mana + character.BaseMana * character.ManaRegenerator, character.BaseMana);
        }

        public CharacterViewModel GetCharacterViewModel(int characterId)
        {
            var character = this.GetCharacterById(characterId);

            List<CharacterViewModel> characterViewModels =
                new List<CharacterViewModel>(this.GetAllCharacterViewModelsInAccount(character.AccountId));

            CharacterViewModel characterViewModel = characterViewModels.Where(vm => vm.Name == character.Name).SingleOrDefault();

            return characterViewModel;
        }

        public IEnumerable<CharacterViewModel> GetAllCharacterViewModelsInAccount(int accountId)
        {
            var account = this.db.Accounts.FirstOrDefault(a => a.Id == accountId);

            if (account != null)
            {
                return db.Characters.Where(ch => ch.IsDeleted == false && ch.AccountId == accountId)
                    .Select(MapToCharacterViewModel())
                    .OrderBy(ch => ch.DateCreated)
                    .ToList();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.AccountDoesNotExist);
            }
        }

        private void UnaffectCharacterWithEachActiveSkill(Character character)
        {
            foreach (var skill in character.Skills.Where(s => s.IsActivated && s.GetType() != typeof(IAura)))
            {
                skill.UnaffectCharacter(character);
            }
        }

        private static Expression<Func<Character, CharacterViewModel>> MapToCharacterViewModel()
        {
            return x => new CharacterViewModel
            {
                Name = x.Name,
                Type = x.GetType().Name,
                Level = x.Level,
                DateCreated = x.DateCreated,
                Experience = x.Experience,
                BaseLife = (int)x.BaseLife,
                Life = (int)x.Life,
                BaseMana = (int)x.BaseMana,
                Mana = (int)x.Mana,
                Damage = (int)x.Damage,
                Defense = (int)x.Defense,
                FireResistance = (int)x.FireResistance,
                LightningResistance = (int)x.LightningResistance,
                ColdResistance = (int)x.ColdResistance,
                PoisonResistance = (int)x.PoisonResistance,
                GoldCoins = x.GoldCoins,
                Account = x.Account,
                ChanceOfCriticalHit = x.ChanceOfCriticalHit
            };
        }

        public string FormatCharacterFightViewModelToString(CharacterViewModel characterViewModel)
        {
            var result = string.Format(CharacterConstants.CharacterStringFightViewFormat,
                 characterViewModel.Name,
                 characterViewModel.Type,
                 characterViewModel.Level,
                 characterViewModel.Life,
                 characterViewModel.BaseLife,
                 characterViewModel.Mana,
                 characterViewModel.BaseMana,
                 characterViewModel.Damage,
                 characterViewModel.ChanceOfCriticalHit,
                 characterViewModel.Defense,
                 characterViewModel.FireResistance,
                 characterViewModel.LightningResistance,
                 characterViewModel.ColdResistance,
                 characterViewModel.PoisonResistance);

            return result;
        }

        public string FormatCharacterLobbyViewModelToString(CharacterViewModel characterViewModel)
        {
            var result = string.Format(CharacterConstants.CharacterStringLobbyViewFormat,
                 characterViewModel.Level,
                 characterViewModel.Experience,
                 characterViewModel.Life,
                 characterViewModel.Mana,
                 characterViewModel.Damage,
                 characterViewModel.ChanceOfCriticalHit,
                 characterViewModel.Defense,
                 characterViewModel.FireResistance,
                 characterViewModel.LightningResistance,
                 characterViewModel.ColdResistance,
                 characterViewModel.PoisonResistance,
                 characterViewModel.GoldCoins);

            return result;
        }
    }
}


//Name = x.Name,
//DateCreated = x.DateCreated,
//Level = x.Level,
//Experience = x.Experience,
//BaseLife = x.BaseLife,
//Life = x.Life,
//BaseMana = x.BaseMana,
//Mana = x.Mana,
//Damage = x.Damage,
//Defense = x.Defense,
//FireResistance = x.FireResistance,
//LightningResistance = x.LightningResistance,
//ColdResistance = x.ColdResistance,
//PoisonResistance = x.PoisonResistance,
//GoldCoins = x.GoldCoins,
//Account = x.Account,

