using ConsoleDiablo2.Common;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Items.Contracts;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ConsoleDiablo2.DataModels.Items.Weapons
{
    public abstract class Weapon : Item, IWeapon
    {
        protected Weapon()
        {
        }

        protected Weapon(int id,
            ItemClass itemClass,
            string name,
            int size,
            int sellValue,
            Bonus skillBonus,
            Bonus allSkillsBonus,
            Gear gear,
            Inventory inventory,
            HashSet<Bonus> bonuses) : base(id, itemClass, name, size, sellValue, skillBonus, allSkillsBonus, gear, inventory, bonuses)
        {
            this.LoadWeaponBonuses();
        }

        [NotMapped]
        public virtual Bonus Accuracy { get; set; }
        [NotMapped]
        public virtual Bonus Damage { get; set; }
        [NotMapped]
        public virtual Bonus ChanceOfCriticalHit { get; set; }
        [NotMapped]
        public virtual Bonus DamageToMonsterType { get; set; }
        [NotMapped]
        public virtual Bonus LifeTap { get; set; }
        [NotMapped]
        public virtual Bonus ManaTap { get; set; }
        [NotMapped]
        public virtual Bonus ElementalSkillDamage { get; set; }

        public bool IgnoreTargetsDefense { get; set; }

        public override void AffectCharacter()
        {
            this.Gear.Character.Damage += this.Damage.Value;

            if (this.ChanceOfCriticalHit != null)
            {
                this.Gear.Character.ChanceOfCriticalHit += this.ChanceOfCriticalHit.Value;
            }

            base.AffectCharacterWithSkillBonus(this.Gear.Character);
            base.AffectCharacterWithAllSkillsBonus(this.Gear.Character);
        }

        public override void UnaffectCharacter()
        {
            this.Gear.Character.Damage -= this.Damage.Value;

            base.UnaffectCharacterWithSkillBonus(this.Gear.Character);
            base.UnaffectCharacterWithAllSkillsBonus(this.Gear.Character);
        }

        public void LoadWeaponBonuses()
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == GlobalConstants.BonusString);

            foreach (var bonus in this.Bonuses)
            {
                if (bonus.Description.Contains(nameof(this.Accuracy)))
                {
                    this.Accuracy = (Bonus)Activator.CreateInstance(type);
                    this.Accuracy.Value = bonus.Value;
                    this.Accuracy.Description = bonus.Description;
                }
                else if (bonus.Description.Contains("Damage:"))
                {
                    this.Damage = (Bonus)Activator.CreateInstance(type);
                    this.Damage.Value = bonus.Value;
                    this.Damage.Description = bonus.Description;
                }
                else if (bonus.Description.Contains("Chance of critical hit"))
                {
                    this.ChanceOfCriticalHit = (Bonus)Activator.CreateInstance(type);
                    this.ChanceOfCriticalHit.Value = bonus.Value;
                    this.ChanceOfCriticalHit.Description = bonus.Description;
                }
                else if (bonus.Description.Contains("damage to"))
                {
                    this.DamageToMonsterType = (Bonus)Activator.CreateInstance(type);
                    this.DamageToMonsterType.Value = bonus.Value;
                    this.DamageToMonsterType.Description = bonus.Description;
                }
                else if (bonus.Description.Contains("Life"))
                {
                    this.LifeTap = (Bonus)Activator.CreateInstance(type);
                    this.LifeTap.Value = bonus.Value;
                    this.LifeTap.Description = bonus.Description;
                }
                else if (bonus.Description.Contains("Mana"))
                {
                    this.ManaTap = (Bonus)Activator.CreateInstance(type);
                    this.ManaTap.Value = bonus.Value;
                    this.ManaTap.Description = bonus.Description;
                }
                else if (bonus.Description.Contains("skill damage"))
                {
                    this.ElementalSkillDamage = (Bonus)Activator.CreateInstance(type);
                    this.ElementalSkillDamage.Value = bonus.Value;
                    this.ElementalSkillDamage.Description = bonus.Description;
                }
                else if (bonus.Description.Contains("Ignore target's defense"))
                {
                    this.IgnoreTargetsDefense = true;
                }
            }
        }
    }
}
