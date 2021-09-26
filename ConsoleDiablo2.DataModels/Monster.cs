using ConsoleDiablo2.Common;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Monsters.Contracts;
using System;

namespace ConsoleDiablo2.DataModels
{
    public abstract class Monster : Being, IMonster
    {
        private readonly Random random = new Random();

        public Monster(Character character) : base()
        {
            this.HasAffectedCharacter = false;
            InitializeMonsterCharacteristics(character);
        }

        public MonsterRank Type { get; set; }

        public int Mana { get; set; }

        public int ManaCostForAbility { get; set; }

        public byte DroppingIndex { get; set; }

        public bool HasAffectedCharacter { get; set; }

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                Random chanceToBlock = new Random();

                if (character.ChanceToBlock < chanceToBlock.Next(0, BonusConstants.MaxChanceToBlock))
                {
                    if (this.Mana >= this.ManaCostForAbility)
                    {
                        this.UseSpecialAbility(character);
                        this.Mana -= this.ManaCostForAbility;
                    }

                    switch (this.DamageType)
                    {
                        case DamageType.Fire:
                            character.Life = Math.Max(character.Life - this.Damage * (1 - character.FireResistance / GlobalConstants.ResistanceDivider), 0);
                            break;
                        case DamageType.Cold:
                            character.Life = Math.Max(character.Life - this.Damage * (1 - character.ColdResistance / GlobalConstants.ResistanceDivider), 0);
                            character.ManaRegenerator = 0;
                            break;
                        case DamageType.Lightning:
                            character.Life = Math.Max(character.Life - this.Damage * (1 - character.LightningResistance / GlobalConstants.ResistanceDivider), 0);
                            break;
                        case DamageType.Poison:
                            character.Life = Math.Max(character.Life - this.Damage * (1 - character.PoisonResistance / GlobalConstants.ResistanceDivider), 0);
                            character.IsPoisoned = true;
                            character.BeingPoisoned(character.Life / GlobalConstants.PoisonLifeDivider);
                            break;
                        case DamageType.Physical:
                            character.Life = Math.Max(character.Life - this.Damage * (1 - character.Defense / GlobalConstants.DefenseDivider), 0);
                            break;
                    }
                }
            }
        }

        protected virtual void InitializeMonsterCharacteristics(Character character)
        {
            InitializeMonsterType(character);

            switch (this.Type)
            {
                case MonsterRank.Ordinary:
                    this.Damage = this.random.Next(MonsterConstants.OrdinaryMonsterMinDamage, MonsterConstants.OrdinaryMonsterMaxDamage);
                    this.DamageType = (DamageType)this.random.Next((int)DamageType.Physical, (int)DamageType.Poison);

                    this.BaseLife = this.random.Next(MonsterConstants.OrdinaryMonsterMinLife, MonsterConstants.OrdinaryMonsterMaxLife)
                        + character.Level * MonsterConstants.MonsterStatsGradation;
                    this.Life = BaseLife;
                    this.Mana = MonsterConstants.OrdinaryMonsterMana;

                    this.Defense = this.random.Next(MonsterConstants.OrdinaryMonsterMinDefense, MonsterConstants.OrdinaryMonsterMaxDefense);
                    this.FireResistance = (byte)this.random.Next(MonsterConstants.OrdinaryMonsterMinResistance, MonsterConstants.OrdinaryMonsterMaxResistance);
                    this.LightningResistance = (byte)this.random.Next(MonsterConstants.OrdinaryMonsterMinResistance, MonsterConstants.OrdinaryMonsterMaxResistance);
                    this.ColdResistance = (byte)this.random.Next(MonsterConstants.OrdinaryMonsterMinResistance, MonsterConstants.OrdinaryMonsterMaxResistance);
                    this.PoisonResistance = (byte)this.random.Next(MonsterConstants.OrdinaryMonsterMinResistance, MonsterConstants.OrdinaryMonsterMaxResistance);

                    this.DroppingIndex = (byte)this.random.Next(0, MonsterConstants.OrdinaryMonsterMaxDroppingIndex);
                    break;

                case MonsterRank.Strong:
                    this.Damage = this.random.Next(MonsterConstants.StrongMonsterMinDamage, MonsterConstants.StrongMonsterMaxDamage) + character.Level * MonsterConstants.MonsterStatsGradation;
                    this.DamageType = (DamageType)this.random.Next((int)DamageType.Physical, (int)DamageType.Poison);

                    this.BaseLife = this.random.Next(MonsterConstants.StrongMonsterMinLife, MonsterConstants.StrongMonsterMaxLife)
                        + character.Level * MonsterConstants.MonsterStatsGradation;
                    this.Life = BaseLife;
                    this.Mana = MonsterConstants.StrongMonsterMana;

                    this.Defense = this.random.Next(MonsterConstants.StrongMonsterMinDefense, MonsterConstants.StrongMonsterMaxDefense);
                    this.FireResistance = (byte)this.random.Next(MonsterConstants.StrongMonsterMinResistance, MonsterConstants.StrongMonsterMaxResistance);
                    this.LightningResistance = (byte)this.random.Next(MonsterConstants.StrongMonsterMinResistance, MonsterConstants.StrongMonsterMaxResistance);
                    this.ColdResistance = (byte)this.random.Next(MonsterConstants.StrongMonsterMinResistance, MonsterConstants.StrongMonsterMaxResistance);
                    this.PoisonResistance = (byte)this.random.Next(MonsterConstants.StrongMonsterMinResistance, MonsterConstants.StrongMonsterMaxResistance);

                    this.DroppingIndex = (byte)this.random.Next(0, MonsterConstants.StrongMonsterMaxDroppingIndex);
                    break;

                case MonsterRank.Champion:
                    this.Damage = this.random.Next(MonsterConstants.ChampionMonsterMinDamage, MonsterConstants.ChampionMonsterMaxDamage) + character.Level * MonsterConstants.MonsterStatsGradation;
                    this.DamageType = (DamageType)this.random.Next((int)DamageType.Physical, (int)DamageType.Poison);

                    this.BaseLife = this.random.Next(MonsterConstants.ChampionMonsterMinLife, MonsterConstants.ChampionMonsterMaxLife)
                        + character.Level * MonsterConstants.MonsterStatsGradation;
                    this.Mana = MonsterConstants.ChampionMonsterMana;
                    this.Life = BaseLife;

                    this.Defense = this.random.Next(MonsterConstants.ChampionMonsterMinDefense, MonsterConstants.ChampionMonsterMaxDefense);
                    this.FireResistance = (byte)this.random.Next(MonsterConstants.ChampionMonsterMinResistance, MonsterConstants.ChampionMonsterMaxResistance);
                    this.LightningResistance = (byte)this.random.Next(MonsterConstants.ChampionMonsterMinResistance, MonsterConstants.ChampionMonsterMaxResistance);
                    this.ColdResistance = (byte)this.random.Next(MonsterConstants.ChampionMonsterMinResistance, MonsterConstants.ChampionMonsterMaxResistance);
                    this.PoisonResistance = (byte)this.random.Next(MonsterConstants.ChampionMonsterMinResistance, MonsterConstants.ChampionMonsterMaxResistance);

                    this.DroppingIndex = (byte)this.random.Next(0, MonsterConstants.ChampionMonsterMaxDroppingIndex);
                    break;

                case MonsterRank.Legendary:
                    this.Damage = this.random.Next(MonsterConstants.LegendaryMonsterMinDamage, MonsterConstants.LegendaryMonsterMaxDamage) + character.Level * MonsterConstants.MonsterStatsGradation;
                    this.DamageType = (DamageType)this.random.Next((int)DamageType.Physical, (int)DamageType.Poison);

                    this.BaseLife = this.random.Next(MonsterConstants.LegendaryMonsterMinLife, MonsterConstants.LegendaryMonsterMaxLife)
                        + character.Level * MonsterConstants.MonsterStatsGradation;
                    this.Mana = MonsterConstants.LegendaryMonsterMana;
                    this.Life = BaseLife;

                    this.Defense = this.random.Next(MonsterConstants.LegendaryMonsterMinDefense, MonsterConstants.LegendaryMonsterMaxDefense);
                    this.FireResistance = (byte)this.random.Next(MonsterConstants.LegendaryMonsterMinResistance, MonsterConstants.LegendaryMonsterMaxResistance);
                    this.LightningResistance = (byte)this.random.Next(MonsterConstants.LegendaryMonsterMinResistance, MonsterConstants.LegendaryMonsterMaxResistance);
                    this.ColdResistance = (byte)this.random.Next(MonsterConstants.LegendaryMonsterMinResistance, MonsterConstants.LegendaryMonsterMaxResistance);
                    this.PoisonResistance = (byte)this.random.Next(MonsterConstants.LegendaryMonsterMinResistance, MonsterConstants.LegendaryMonsterMaxResistance);

                    this.DroppingIndex = (byte)this.random.Next(0, MonsterConstants.LegendaryMonsterMaxDroppingIndex);
                    break;

                default:
                    throw new ArgumentException(ExceptionMessages.NoSuchMonsterTypeMessage);
            }

            this.ManaCostForAbility = MonsterConstants.MonsterManaCostForAbility;
        }

        protected virtual void InitializeMonsterType(Character character)
        {
            if (character.Level <= 6)
            {
                this.Type = MonsterRank.Ordinary;
            }
            else if (character.Level <= 12)
            {
                this.Type = MonsterRank.Strong;
            }
            else if (character.Level <= 18)
            {
                this.Type = MonsterRank.Champion;
            }
            else
            {
                this.Type = MonsterRank.Legendary;
            }
        }

        public abstract void UseSpecialAbility(Character character);

        public abstract void UnaffectCharacter(Character character);
    }
}
