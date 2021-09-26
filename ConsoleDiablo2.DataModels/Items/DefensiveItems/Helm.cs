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
    public class Helm : DefensiveEquipment, IHelm
    {
        Random random = new Random();

        public Helm()
        {
        }

        [NotMapped]
        public Bonus Mana { get; set; }

        public override void AffectCharacter()
        {
            if (this.Mana != null)
            {
                this.Gear.Character.BaseMana += this.Mana.Value;
            }

            base.AffectCharacter();
            base.AffectCharacterWithAllSkillsBonus(this.Gear.Character);
        }

        public override void InitializeItemBonuses(ItemClass itemType)
        {
            this.Size = this.random.Next(DefensiveEquipmentConstants.ShieldMinSize, DefensiveEquipmentConstants.ShieldMaxSize);
            this.SellValue = DefensiveEquipmentConstants.ShieldMaxSellValue * this.Size / (int)itemType;

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == GlobalConstants.BonusString);

            this.Defense = (Bonus)Activator.CreateInstance(type);

            switch (itemType)
            {
                case ItemClass.Ordinary:
                    this.Defense.Value = this.random.Next(DefensiveEquipmentConstants.HelmMinDefense,
                        DefensiveEquipmentConstants.HelmMaxDefense);
                    break;

                case ItemClass.Superior:
                    this.Mana = (Bonus)Activator.CreateInstance(type);
                    this.Resistance = (Bonus)Activator.CreateInstance(type);

                    this.Defense.Value = this.random.Next(DefensiveEquipmentConstants.HelmMaxDefense,
                        DefensiveEquipmentConstants.SuperiorHelmMaxDefense);

                    this.Mana.Value = this.random.Next(DefensiveEquipmentConstants.SuperiorHelmMinManaBonus,
                        DefensiveEquipmentConstants.SuperiorHelmMaxManaBonus);
                    this.Mana.Description = String.Concat(BonusConstants.ManaBonusDesc, this.Mana.Value.ToString());

                    this.Resistance.Value = this.random.Next(DefensiveEquipmentConstants.HelmMaxResistanceBonus,
                        DefensiveEquipmentConstants.SuperiorHelmMaxResistanceBonus);
                    this.Resistance.Description = String.Concat(BonusConstants.ResBonusDescs[this.random.Next(0, BonusConstants.ResBonusDescs.Count)], this.Resistance.Value);

                    this.Bonuses.Add(Resistance);
                    this.Bonuses.Add(Mana);
                    break;

                case ItemClass.Magic:
                    this.Mana = (Bonus)Activator.CreateInstance(type);
                    this.Resistance = (Bonus)Activator.CreateInstance(type);

                    this.Defense.Value = this.random.Next(DefensiveEquipmentConstants.SuperiorHelmMaxDefense,
                        DefensiveEquipmentConstants.MagicHelmMaxDefense);
                    this.Mana.Value = this.random.Next(DefensiveEquipmentConstants.SuperiorHelmMaxManaBonus,
                        DefensiveEquipmentConstants.MagicHelmMaxManaBonus);
                    this.Mana.Description = String.Concat(BonusConstants.ManaBonusDesc, this.Mana.Value.ToString());

                    this.Resistance.Value = this.random.Next(DefensiveEquipmentConstants.SuperiorHelmMaxResistanceBonus,
                        DefensiveEquipmentConstants.MagicHelmMaxResistanceBonus);
                    this.Resistance.Description = String.Concat(BonusConstants.ResBonusDescs[this.random.Next(0, BonusConstants.ResBonusDescs.Count)], this.Resistance.Value);

                    this.Bonuses.Add(Resistance);
                    this.Bonuses.Add(Mana);
                    break;

                case ItemClass.Rare:
                    this.Mana = (Bonus)Activator.CreateInstance(type);
                    this.Resistance = (Bonus)Activator.CreateInstance(type);

                    this.Defense.Value = this.random.Next(DefensiveEquipmentConstants.MagicHelmMaxDefense,
                        DefensiveEquipmentConstants.RareHelmMaxDefense);
                    this.Mana.Value = this.random.Next(DefensiveEquipmentConstants.MagicHelmMaxManaBonus,
                        DefensiveEquipmentConstants.RareHelmMaxManaBonus);
                    this.Mana.Description = String.Concat(BonusConstants.ManaBonusDesc, this.Mana.Value.ToString());

                    this.Resistance.Value = this.random.Next(DefensiveEquipmentConstants.MagicHelmMaxResistanceBonus,
                        DefensiveEquipmentConstants.RareHelmMaxResistanceBonus);
                    this.Resistance.Description = String.Concat(BonusConstants.AllResBonusDesc, this.Resistance.Value);

                    this.Bonuses.Add(Mana);
                    this.Bonuses.Add(Resistance);
                    break;

                case ItemClass.Legendary:
                    this.Mana = (Bonus)Activator.CreateInstance(type);
                    this.Resistance = (Bonus)Activator.CreateInstance(type);
                    this.AllSkillsBonus = (Bonus)Activator.CreateInstance(type);

                    this.Defense.Value = this.random.Next(DefensiveEquipmentConstants.RareHelmMaxDefense,
                        DefensiveEquipmentConstants.LegendaryHelmMaxDefense);
                    this.Mana.Value = this.random.Next(DefensiveEquipmentConstants.RareHelmMaxManaBonus,
                        DefensiveEquipmentConstants.LegendaryHelmMaxManaBonus);
                    this.Mana.Description = String.Concat(BonusConstants.ManaBonusDesc, this.Mana.Value.ToString());

                    this.Resistance.Value = this.random.Next(DefensiveEquipmentConstants.RareHelmMaxResistanceBonus,
                        DefensiveEquipmentConstants.LegendaryHelmMaxResistanceBonus);
                    this.Resistance.Description = String.Concat(BonusConstants.AllResBonusDesc, this.Resistance.Value);

                    this.AllSkillsBonus.Value = this.random.Next(WeaponConstants.AllSkillsMinBonusValue, WeaponConstants.AllSkillsMaxBonusValue);
                    this.AllSkillsBonus.Description = String.Concat(this.AllSkillsBonus.Value.ToString(), BonusConstants.AllSkillsDesc);

                    this.Bonuses.Add(Mana);
                    this.Bonuses.Add(Resistance);
                    this.Bonuses.Add(AllSkillsBonus);
                    break;

                default:
                    throw new ArgumentException(ExceptionMessages.NoSuchItemTypeMessage);
            }

            this.Defense.Description = String.Concat(BonusConstants.DefenseBonusDesc, this.Defense.Value.ToString());

            this.Name = String.Concat(itemType, " ", typeof(Helm).Name, ItemConstants.armorNames[random.Next(0, ItemConstants.armorNames.Count - 1)]);

            this.Bonuses.Add(Defense);
        }

        public override void UnaffectCharacter()
        {
            if (this.Mana != null)
            {
                this.Gear.Character.BaseMana -= this.Mana.Value;
            }

            base.UnaffectCharacter();
            base.UnaffectCharacterWithAllSkillsBonus(this.Gear.Character);
        }

        public override void LoadDefensiveEquipmentBonuses()
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == GlobalConstants.BonusString);

            foreach (var bonus in this.Bonuses)
            {
                if (bonus.Description.Contains("Mana:"))
                {
                    this.Mana = (Bonus)Activator.CreateInstance(type);
                    this.Mana.Value = bonus.Value;
                    this.Mana.Description = bonus.Description;

                    break;
                }
            }

            base.LoadDefensiveEquipmentBonuses();   
        }
    }
}
