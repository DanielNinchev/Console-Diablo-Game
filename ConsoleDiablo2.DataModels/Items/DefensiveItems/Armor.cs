using ConsoleDiablo2.Common;
using ConsoleDiablo2.Common.ItemConstants;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Items.Contracts;

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ConsoleDiablo2.DataModels.Items.DefensiveItems
{
    public class Armor : DefensiveEquipment, IArmor
    {
        private Random random = new Random();

        [NotMapped]
        public Bonus Life { get; set; }

        public override void AffectCharacter()
        {
            if (this.Life != null)
            {
                this.Gear.Character.BaseLife += this.Life.Value;
            }

            base.AffectCharacter();
            base.AffectCharacterWithAllSkillsBonus(this.Gear.Character);
        }

        public override void InitializeItemBonuses(ItemClass itemType)
        {
            this.Size = DefensiveEquipmentConstants.ArmorSize;
            this.SellValue = DefensiveEquipmentConstants.ShieldMaxSellValue * this.Size / (int)itemType;

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == GlobalConstants.BonusString);

            this.Defense = (Bonus)Activator.CreateInstance(type);

            switch (itemType)
            {
                case ItemClass.Ordinary:
                    this.Defense.Value = this.random.Next(DefensiveEquipmentConstants.ArmorMinDefense,
                        DefensiveEquipmentConstants.ArmorMaxDefense);
                    break;

                case ItemClass.Superior:
                    this.Life = (Bonus)Activator.CreateInstance(type);
                    this.Resistance = (Bonus)Activator.CreateInstance(type);

                    this.Defense.Value = this.random.Next(DefensiveEquipmentConstants.ArmorMaxDefense,
                        DefensiveEquipmentConstants.SuperiorArmorMaxDefense);

                    this.Life.Value = this.random.Next(DefensiveEquipmentConstants.SuperiorArmorMinLifeBonus,
                        DefensiveEquipmentConstants.SuperiorArmorMaxLifeBonus);
                    this.Life.Description = String.Concat(BonusConstants.LifeBonusDesc, this.Life.Value.ToString());

                    this.Resistance.Value = this.random.Next(DefensiveEquipmentConstants.ArmorMaxResistanceBonus,
                        DefensiveEquipmentConstants.SuperiorArmorMaxResistanceBonus);
                    this.Resistance.Description = String.Concat(BonusConstants.ResBonusDescs[this.random.Next(0, BonusConstants.ResBonusDescs.Count)], this.Resistance.Value);

                    this.Bonuses.Add(Resistance);
                    this.Bonuses.Add(Life);
                    break;

                case ItemClass.Magic:
                    this.Life = (Bonus)Activator.CreateInstance(type);
                    this.Resistance = (Bonus)Activator.CreateInstance(type);

                    this.Defense.Value = this.random.Next(DefensiveEquipmentConstants.SuperiorArmorMaxDefense,
                        DefensiveEquipmentConstants.MagicArmorMaxDefense);
                    this.Life.Value = this.random.Next(DefensiveEquipmentConstants.SuperiorArmorMaxLifeBonus,
                        DefensiveEquipmentConstants.MagicArmorMaxLifeBonus);
                    this.Life.Description = String.Concat(BonusConstants.LifeBonusDesc, this.Life.Value.ToString());

                    this.Resistance.Value = this.random.Next(DefensiveEquipmentConstants.SuperiorArmorMaxResistanceBonus,
                        DefensiveEquipmentConstants.MagicArmorMaxResistanceBonus);
                    this.Resistance.Description = String.Concat(BonusConstants.ResBonusDescs[this.random.Next(0, BonusConstants.ResBonusDescs.Count)], this.Resistance.Value);

                    this.Bonuses.Add(Resistance);
                    this.Bonuses.Add(Life);
                    break;

                case ItemClass.Rare:
                    this.Life = (Bonus)Activator.CreateInstance(type);
                    this.Resistance = (Bonus)Activator.CreateInstance(type);

                    this.Defense.Value = this.random.Next(DefensiveEquipmentConstants.MagicArmorMaxDefense,
                        DefensiveEquipmentConstants.RareArmorMaxDefense);
                    this.Life.Value = this.random.Next(DefensiveEquipmentConstants.MagicArmorMaxLifeBonus,
                        DefensiveEquipmentConstants.RareArmorMaxLifeBonus);
                    this.Life.Description = String.Concat(BonusConstants.LifeBonusDesc, this.Life.Value.ToString());

                    this.Resistance.Value = this.random.Next(DefensiveEquipmentConstants.MagicArmorMaxResistanceBonus,
                        DefensiveEquipmentConstants.RareArmorMaxResistanceBonus);
                    this.Resistance.Description = String.Concat(BonusConstants.AllResBonusDesc, this.Resistance.Value);

                    this.Bonuses.Add(Life);
                    this.Bonuses.Add(Resistance);
                    break;

                case ItemClass.Legendary:
                    this.Life = (Bonus)Activator.CreateInstance(type);
                    this.Resistance = (Bonus)Activator.CreateInstance(type);
                    this.AllSkillsBonus = (Bonus)Activator.CreateInstance(type);

                    this.Defense.Value = this.random.Next(DefensiveEquipmentConstants.RareArmorMaxDefense,
                        DefensiveEquipmentConstants.LegendaryArmorMaxDefense);
                    this.Life.Value = this.random.Next(DefensiveEquipmentConstants.RareArmorMaxLifeBonus,
                        DefensiveEquipmentConstants.LegendaryArmorMaxLifeBonus);
                    this.Life.Description = String.Concat(BonusConstants.LifeBonusDesc, this.Life.Value.ToString());

                    this.Resistance.Value = this.random.Next(DefensiveEquipmentConstants.RareArmorMaxResistanceBonus,
                        DefensiveEquipmentConstants.LegendaryArmorMaxResistanceBonus);
                    this.Resistance.Description = String.Concat(BonusConstants.AllResBonusDesc, this.Resistance.Value);

                    this.AllSkillsBonus.Value = this.random.Next(WeaponConstants.AllSkillsMinBonusValue, WeaponConstants.AllSkillsMaxBonusValue);
                    this.AllSkillsBonus.Description = String.Concat(this.AllSkillsBonus.Value.ToString(), BonusConstants.AllSkillsDesc);

                    this.Bonuses.Add(Life);
                    this.Bonuses.Add(Resistance);
                    this.Bonuses.Add(AllSkillsBonus);
                    break;

                default:
                    throw new ArgumentException(ExceptionMessages.NoSuchItemTypeMessage);
            }

            this.Defense.Description = String.Concat(BonusConstants.DefenseBonusDesc, this.Defense.Value.ToString());

            this.Name = String.Concat(itemType, " ", typeof(Armor).Name, ItemConstants.armorNames[random.Next(0, ItemConstants.armorNames.Count - 1)]);

            this.Bonuses.Add(Defense);
        }

        public override void UnaffectCharacter()
        {
            if (this.Life != null)
            {
                this.Gear.Character.BaseLife -= this.Life.Value;
            }

            base.UnaffectCharacter();
            base.UnaffectCharacterWithAllSkillsBonus(this.Gear.Character);
        }

        public override void LoadDefensiveEquipmentBonuses()
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == GlobalConstants.BonusString);

            foreach (var bonus in this.Bonuses)
            {
                if (bonus.Description.Contains("Life:"))
                {
                    this.Life = (Bonus)Activator.CreateInstance(type);
                    this.Life.Value = bonus.Value;
                    this.Life.Description = bonus.Description;

                    break;
                }
            }

            base.LoadDefensiveEquipmentBonuses();
        }
    }
}
