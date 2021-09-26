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
    public class Shield : DefensiveEquipment, IShield
    {
        private Random random = new Random();

        public Shield()
        {

        }

        [NotMapped]
        public Bonus ChanceToBlock { get; set; }

        [NotMapped]
        public Bonus SmiteDamage { get; set; }

        public override void AffectCharacter()
        {
            this.Gear.Character.ChanceToBlock += this.ChanceToBlock.Value;
            this.Gear.Character.Damage += this.SmiteDamage.Value;

            base.AffectCharacter();
            base.AffectCharacterWithSkillBonus(this.Gear.Character);
            base.AffectCharacterWithAllSkillsBonus(this.Gear.Character);
        }

        public override void InitializeItemBonuses(ItemClass itemType)
        {
            this.Size = this.random.Next(DefensiveEquipmentConstants.ShieldMinSize, DefensiveEquipmentConstants.ShieldMaxSize);
            this.SellValue = DefensiveEquipmentConstants.ShieldMaxSellValue * this.Size / (int)itemType;

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == GlobalConstants.BonusString);

            this.ChanceToBlock = (Bonus)Activator.CreateInstance(type);
            this.Defense = (Bonus)Activator.CreateInstance(type);
            this.SmiteDamage = (Bonus)Activator.CreateInstance(type);

            switch (itemType)
            {
                case ItemClass.Ordinary:
                    this.ChanceToBlock.Value = this.random.Next(DefensiveEquipmentConstants.ShieldMinChanceToBlock,
                        DefensiveEquipmentConstants.ShieldMaxChanceToBlock);
                    this.Defense.Value = this.random.Next(DefensiveEquipmentConstants.ShieldMinDefense,
                        DefensiveEquipmentConstants.ShieldMaxDefense);
                    this.SmiteDamage.Value = this.random.Next(DefensiveEquipmentConstants.ShieldMinSmiteDamageBonus,
                        DefensiveEquipmentConstants.ShieldMaxSmiteDamageBonus);
                    break;

                case ItemClass.Superior:
                    this.ChanceToBlock.Value = this.random.Next(DefensiveEquipmentConstants.ShieldMaxChanceToBlock,
                        DefensiveEquipmentConstants.SuperiorShieldMaxChanceToBlock);
                    this.Defense.Value = this.random.Next(DefensiveEquipmentConstants.ShieldMaxDefense,
                        DefensiveEquipmentConstants.SuperiorShieldMaxDefense);
                    this.SmiteDamage.Value = this.random.Next(DefensiveEquipmentConstants.ShieldMaxSmiteDamageBonus,
                        DefensiveEquipmentConstants.SuperiorShieldMaxSmiteDamageBonus);

                    this.Resistance = (Bonus)Activator.CreateInstance(type);

                    this.Resistance.Value = this.random.Next(DefensiveEquipmentConstants.ShieldMaxResistanceBonus,
                        DefensiveEquipmentConstants.SuperiorShieldMaxResistanceBonus);
                    this.Resistance.Description = String.Concat(BonusConstants.ResBonusDescs[this.random.Next(0, BonusConstants.ResBonusDescs.Count)], this.Resistance.Value);

                    this.Bonuses.Add(Resistance);
                    break;

                case ItemClass.Magic:
                    this.SkillBonus = (Bonus)Activator.CreateInstance(type);

                    this.ChanceToBlock.Value = this.random.Next(DefensiveEquipmentConstants.SuperiorShieldMaxChanceToBlock,
                        DefensiveEquipmentConstants.MagicShieldMaxChanceToBlock);
                    this.Defense.Value = this.random.Next(DefensiveEquipmentConstants.SuperiorShieldMaxDefense,
                        DefensiveEquipmentConstants.MagicShieldMaxDefense);
                    this.SmiteDamage.Value = this.random.Next(DefensiveEquipmentConstants.SuperiorShieldMaxSmiteDamageBonus,
                        DefensiveEquipmentConstants.MagicShieldMaxSmiteDamageBonus);

                    this.Resistance = (Bonus)Activator.CreateInstance(type);

                    this.Resistance.Value = this.random.Next(DefensiveEquipmentConstants.SuperiorShieldMaxResistanceBonus,
                        DefensiveEquipmentConstants.MagicShieldMaxResistanceBonus);
                    this.Resistance.Description = String.Concat(BonusConstants.ResBonusDescs[this.random.Next(0, BonusConstants.ResBonusDescs.Count)], this.Resistance.Value);

                    this.SkillBonus.Value = WeaponConstants.RareWeaponSkillBonusValue;
                    this.SkillBonus.Description = String.Concat(this.SkillBonus.Value.ToString(),
                        BonusConstants.To, BonusConstants.AxeSkillBonuses[random.Next(0, BonusConstants.AxeSkillBonuses.Count - 1)]);

                    this.Bonuses.Add(Resistance);
                    this.Bonuses.Add(SkillBonus);
                    break;

                case ItemClass.Rare:
                    this.SkillBonus = (Bonus)Activator.CreateInstance(type);

                    this.ChanceToBlock.Value = this.random.Next(DefensiveEquipmentConstants.MagicShieldMaxChanceToBlock,
                        DefensiveEquipmentConstants.RareShieldMaxChanceToBlock);
                    this.Defense.Value = this.random.Next(DefensiveEquipmentConstants.MagicShieldMaxDefense,
                        DefensiveEquipmentConstants.RareShieldMaxDefense);
                    this.SmiteDamage.Value = this.random.Next(DefensiveEquipmentConstants.MagicShieldMaxSmiteDamageBonus,
                        DefensiveEquipmentConstants.RareShieldMaxSmiteDamageBonus);

                    this.Resistance = (Bonus)Activator.CreateInstance(type);
                    this.Resistance.Value = this.random.Next(DefensiveEquipmentConstants.MagicShieldMaxResistanceBonus,
                        DefensiveEquipmentConstants.RareShieldMaxResistanceBonus);
                    this.Resistance.Description = String.Concat(BonusConstants.AllResBonusDesc, this.Resistance.Value);

                    this.SkillBonus.Value = WeaponConstants.RareWeaponSkillBonusValue;
                    this.SkillBonus.Description = String.Concat(this.SkillBonus.Value.ToString(),
                        BonusConstants.To, BonusConstants.AxeSkillBonuses[random.Next(0, BonusConstants.AxeSkillBonuses.Count - 1)]);

                    this.Bonuses.Add(Resistance);
                    this.Bonuses.Add(SkillBonus);
                    break;

                case ItemClass.Legendary:
                    this.SkillBonus = (Bonus)Activator.CreateInstance(type);
                    this.AllSkillsBonus = (Bonus)Activator.CreateInstance(type);

                    this.ChanceToBlock.Value = this.random.Next(DefensiveEquipmentConstants.RareShieldMaxChanceToBlock,
                        DefensiveEquipmentConstants.LegendaryShieldMaxChanceToBlock);
                    this.Defense.Value = this.random.Next(DefensiveEquipmentConstants.RareShieldMaxDefense,
                        DefensiveEquipmentConstants.LegendaryShieldMaxDefense);
                    this.SmiteDamage.Value = this.random.Next(DefensiveEquipmentConstants.RareShieldMaxSmiteDamageBonus,
                        DefensiveEquipmentConstants.LegendaryShieldMaxSmiteDamageBonus);

                    this.Resistance = (Bonus)Activator.CreateInstance(type);
                    this.Resistance.Value = this.random.Next(DefensiveEquipmentConstants.RareShieldMaxResistanceBonus,
                        DefensiveEquipmentConstants.LegendaryShieldMaxResistanceBonus);
                    this.Resistance.Description = String.Concat(BonusConstants.AllResBonusDesc, this.Resistance.Value);

                    this.SkillBonus.Value = WeaponConstants.LegendaryWeaponSkillBonusValue;
                    this.SkillBonus.Description = String.Concat(this.SkillBonus.Value.ToString(),
                        BonusConstants.To, BonusConstants.AxeSkillBonuses[random.Next(0, BonusConstants.AxeSkillBonuses.Count - 1)]);

                    this.AllSkillsBonus.Value = this.random.Next(WeaponConstants.AllSkillsMinBonusValue, WeaponConstants.AllSkillsMaxBonusValue);
                    this.AllSkillsBonus.Description = String.Concat(this.AllSkillsBonus.Value.ToString(), BonusConstants.AllSkillsDesc);

                    this.Bonuses.Add(Resistance);
                    this.Bonuses.Add(AllSkillsBonus);
                    this.Bonuses.Add(SkillBonus);
                    break;

                default:
                    throw new ArgumentException(ExceptionMessages.NoSuchItemTypeMessage);
            }

            this.ChanceToBlock.Description = String.Concat(BonusConstants.ChanceToBlockBonusDesc, this.ChanceToBlock.Value.ToString());
            this.Defense.Description = String.Concat(BonusConstants.DefenseBonusDesc, this.Defense.Value.ToString());
            this.SmiteDamage.Description = String.Concat(BonusConstants.SmiteDamageDesc, this.SmiteDamage.Value.ToString());

            this.Name = String.Concat(itemType, " ", typeof(Shield).Name, ItemConstants.armorNames[random.Next(0, ItemConstants.armorNames.Count - 1)]);

            this.Bonuses.Add(ChanceToBlock);
            this.Bonuses.Add(Defense);
            this.Bonuses.Add(SmiteDamage);
        }

        public override void UnaffectCharacter()
        {
            this.Gear.Character.ChanceToBlock -= this.ChanceToBlock.Value;
            this.Gear.Character.Damage -= this.SmiteDamage.Value;

            base.UnaffectCharacter();
            base.UnaffectCharacterWithSkillBonus(this.Gear.Character);
            base.UnaffectCharacterWithAllSkillsBonus(this.Gear.Character);
        }

        public override void LoadDefensiveEquipmentBonuses()
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == GlobalConstants.BonusString);

            foreach (var bonus in this.Bonuses)
            {
                if (bonus.Description.Contains("Chance to Block:"))
                {
                    this.ChanceToBlock = (Bonus)Activator.CreateInstance(type);
                    this.ChanceToBlock.Value = bonus.Value;
                    this.ChanceToBlock.Description = bonus.Description;
                }
                else if (bonus.Description.Contains("Smite Damage:"))
                {
                    this.SmiteDamage = (Bonus)Activator.CreateInstance(type);
                    this.SmiteDamage.Value = bonus.Value;
                    this.SmiteDamage.Description = bonus.Description;
                }
            }

            base.LoadDefensiveEquipmentBonuses();
        }
    }
}
