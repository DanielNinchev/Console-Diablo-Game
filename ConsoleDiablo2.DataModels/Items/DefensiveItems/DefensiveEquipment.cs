using ConsoleDiablo2.Common;
using ConsoleDiablo2.DataModels.Items.Contracts;

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ConsoleDiablo2.DataModels.Items.DefensiveItems
{
    public abstract class DefensiveEquipment : Item, IDefensiveEquipment
    {
        protected DefensiveEquipment()
        {
        }

        [NotMapped]
        public Bonus Defense { get; set; }

        [NotMapped]
        public Bonus Resistance { get; set; }

        public override void AffectCharacter()
        {
            this.Gear.Character.Defense += this.Defense.Value;

            if (this.Resistance != null)
            {
                if (this.Resistance.Description.Contains("Fire"))
                {
                    this.Gear.Character.FireResistance += this.Resistance.Value;
                }
                else if (this.Resistance.Description.Contains("Lightning"))
                {
                    this.Gear.Character.LightningResistance += this.Resistance.Value;
                }
                else if (this.Resistance.Description.Contains("Cold"))
                {
                    this.Gear.Character.ColdResistance += this.Resistance.Value;
                }
                else if (this.Resistance.Description.Contains("Poison"))
                {
                    this.Gear.Character.PoisonResistance += this.Resistance.Value;
                }
                else
                {
                    this.Gear.Character.FireResistance += this.Resistance.Value;
                    this.Gear.Character.LightningResistance += this.Resistance.Value;
                    this.Gear.Character.ColdResistance += this.Resistance.Value;
                    this.Gear.Character.PoisonResistance += this.Resistance.Value;
                }
            }

            base.AffectCharacterWithSkillBonus(this.Gear.Character);
            base.AffectCharacterWithAllSkillsBonus(this.Gear.Character);
        }

        public override void UnaffectCharacter()
        {
            this.Gear.Character.Defense -= this.Defense.Value;

            if (this.Resistance != null)
            {
                if (this.Resistance.Description.Contains("Fire"))
                {
                    this.Gear.Character.FireResistance -= this.Resistance.Value;
                }
                else if (this.Resistance.Description.Contains("Lightning"))
                {
                    this.Gear.Character.LightningResistance -= this.Resistance.Value;
                }
                else if (this.Resistance.Description.Contains("Cold"))
                {
                    this.Gear.Character.ColdResistance -= this.Resistance.Value;
                }
                else if (this.Resistance.Description.Contains("Poison"))
                {
                    this.Gear.Character.PoisonResistance -= this.Resistance.Value;
                }
                else
                {
                    this.Gear.Character.FireResistance -= this.Resistance.Value;
                    this.Gear.Character.LightningResistance -= this.Resistance.Value;
                    this.Gear.Character.ColdResistance -= this.Resistance.Value;
                    this.Gear.Character.PoisonResistance -= this.Resistance.Value;
                }
            }

            base.UnaffectCharacterWithSkillBonus(this.Gear.Character);
            base.UnaffectCharacterWithAllSkillsBonus(this.Gear.Character);
        }

        public virtual void LoadDefensiveEquipmentBonuses()
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == GlobalConstants.BonusString);

            foreach (var bonus in this.Bonuses)
            {
                if (bonus.Description.Contains("Defense:"))
                {
                    this.Defense = (Bonus)Activator.CreateInstance(type);
                    this.Defense.Value = bonus.Value;
                    this.Defense.Description = bonus.Description;
                }
                else if (bonus.Description.Contains("resistance"))
                {
                    this.Resistance = (Bonus)Activator.CreateInstance(type);
                    this.Resistance.Value = bonus.Value;
                    this.Resistance.Description = bonus.Description;
                }
            }
        }
    }
}
