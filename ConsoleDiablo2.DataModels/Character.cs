using ConsoleDiablo2.Common;
using ConsoleDiablo2.DataModels.Characters.Contracts;
using ConsoleDiablo2.DataModels.SkillTrees;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleDiablo2.DataModels
{
    public abstract class Character : Being, ICharacter
    {
        protected Character(
            string name, 
            bool isDeleted,
            int damage, 
            int baseLife, 
            int baseMana) : base()
        {
            this.Name = name;
            this.Experience = 0;
            this.Level = 1;
            this.IsDeleted = isDeleted;

            this.Damage = damage;
            this.ChanceOfCriticalHit = 0;

            this.Defense = 0;
            this.ChanceToBlock = 0;

            this.BaseLife = baseLife;
            this.Life = baseLife;
            this.LifeRegenerator = CharacterConstants.LifeRegenerator;
            this.LifeTap = 0;

            this.BaseMana = baseMana;
            this.Mana = baseMana;
            this.ManaRegenerator = CharacterConstants.ManaRegenerator;
            this.ManaTap = 0;

            this.FireResistance = 0;
            this.LightningResistance = 0;
            this.ColdResistance = 0;
            this.PoisonResistance = 0;

            this.GoldCoins = 0;

            this.HasLeveledUp = false;

            this.Skills = new HashSet<Skill>();

            this.StatusPoints = 0;
            this.SkillPoints = 0;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Experience { get; set; }

        public byte Level { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DateCreated { get; set; }

        public double BaseMana { get; set; }

        public double Mana { get; set; }

        public double ManaRegenerator { get; set; }

        public int GoldCoins { get; set; }

        [Required]
        [ForeignKey(nameof(Account))]
        public int AccountId { get; set; }
        public Account Account { get; set; }

        [Required]
        [ForeignKey(nameof(Gear))]
        public int GearId { get; set; }
        public virtual Gear Gear { get; set; }

        [Required]
        [ForeignKey(nameof(Inventory))]
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }

        public bool HasLeveledUp { get; set; }

        public int ChanceOfCriticalHit { get; set; }

        public int ChanceToBlock { get; set; }

        public int LifeTap { get; set; }

        public int ManaTap { get; set; }

        public int StatusPoints { get; set; }

        public int SkillPoints { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        [NotMapped]
        public Tree<string> SkillTree { get; set; }
    }
}