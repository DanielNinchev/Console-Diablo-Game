using ConsoleDiablo2.Common;
using ConsoleDiablo2.Common.ItemConstants;
using ConsoleDiablo2.DataModels.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleDiablo2.DataModels.Items.Weapons
{
    public class Scepter : Weapon
    {
        private readonly Random random = new Random();

        public Scepter()
        {

        }

        public Scepter(int id,
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

        }

        public override void InitializeItemBonuses(ItemClass itemType)
        {
            this.Size = this.random.Next(WeaponConstants.ScepterMinSize, WeaponConstants.ScepterMaxSize);
            this.SellValue = WeaponConstants.ScepterMaxSellValue * this.Size / (int)itemType;

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == GlobalConstants.BonusString);

            this.Damage = (Bonus)Activator.CreateInstance(type);
            this.Accuracy = (Bonus)Activator.CreateInstance(type);

            switch (itemType)
            {
                case ItemClass.Ordinary:
                    this.Damage.Value = this.random.Next(WeaponConstants.ScepterMinDamageBonus, WeaponConstants.ScepterMaxDamageBonus);
                    break;

                case ItemClass.Superior:
                    this.DamageToMonsterType = (Bonus)Activator.CreateInstance(type);

                    this.Damage.Value = this.random.Next(WeaponConstants.ScepterMaxDamageBonus, WeaponConstants.SuperiorScepterMaxDamageBonus);
                    this.DamageToMonsterType.Value = WeaponConstants.SuperiorWeaponMonsterTypeDamageBonus;
                    this.DamageToMonsterType.Description = String.Concat(BonusConstants.Plus,
                        this.DamageToMonsterType.Value.ToString(), BonusConstants.DamageToMonsterTypeDesc,
                        (MonsterType)this.random.Next(GlobalConstants.EnumMinValue, GlobalConstants.MonsterTypeEnumMaxValue));

                    this.Bonuses.Add(DamageToMonsterType);
                    break;

                case ItemClass.Magic:
                    this.DamageToMonsterType = (Bonus)Activator.CreateInstance(type);
                    this.SkillBonus = (Bonus)Activator.CreateInstance(type);

                    this.Damage.Value = this.random.Next(WeaponConstants.SuperiorScepterMaxDamageBonus, WeaponConstants.MagicScepterMaxDamageBonus);

                    this.DamageToMonsterType.Value = WeaponConstants.MagicWeaponMonsterTypeDamageBonus;
                    this.DamageToMonsterType.Description = String.Concat(BonusConstants.Plus,
                        this.DamageToMonsterType.Value.ToString(), BonusConstants.DamageToMonsterTypeDesc,
                        (MonsterType)this.random.Next(GlobalConstants.EnumMinValue, GlobalConstants.MonsterTypeEnumMaxValue));

                    this.SkillBonus.Value = WeaponConstants.MagicWeaponSkillBonusValue;
                    this.SkillBonus.Description = String.Concat(this.SkillBonus.Value.ToString(),
                        BonusConstants.To, BonusConstants.ScepterSkillBonuses[random.Next(0, BonusConstants.ScepterSkillBonuses.Count - 1)]);

                    this.Bonuses.Add(SkillBonus);
                    this.Bonuses.Add(DamageToMonsterType);
                    break;

                case ItemClass.Rare:
                    this.DamageToMonsterType = (Bonus)Activator.CreateInstance(type);
                    this.SkillBonus = (Bonus)Activator.CreateInstance(type);
                    this.ChanceOfCriticalHit = (Bonus)Activator.CreateInstance(type);

                    this.Damage.Value = this.random.Next(WeaponConstants.MagicScepterMaxDamageBonus, WeaponConstants.RareScepterMaxDamageBonus);

                    this.DamageToMonsterType.Value = WeaponConstants.RareWeaponMonsterTypeDamageBonus;
                    this.DamageToMonsterType.Description = String.Concat(BonusConstants.Plus,
                        this.DamageToMonsterType.Value.ToString(), BonusConstants.DamageToMonsterTypeDesc,
                        (MonsterType)this.random.Next(GlobalConstants.EnumMinValue, GlobalConstants.MonsterTypeEnumMaxValue));

                    this.SkillBonus.Value = WeaponConstants.RareWeaponSkillBonusValue;
                    this.SkillBonus.Description = String.Concat(this.SkillBonus.Value.ToString(),
                        BonusConstants.To, BonusConstants.ScepterSkillBonuses[random.Next(0, BonusConstants.ScepterSkillBonuses.Count - 1)]);

                    this.ChanceOfCriticalHit.Value = random.Next(WeaponConstants.ScepterMinChanceOfCriticalHit, WeaponConstants.ScepterMaxChanceOfCriticalHit);
                    this.ChanceOfCriticalHit.Description = String.Concat(BonusConstants.ChanceOfCriticalHit,
                        this.ChanceOfCriticalHit.Value.ToString(), BonusConstants.Percentage);

                    this.Bonuses.Add(SkillBonus);
                    this.Bonuses.Add(ChanceOfCriticalHit);
                    this.Bonuses.Add(DamageToMonsterType);
                    break;

                case ItemClass.Legendary:
                    this.DamageToMonsterType = (Bonus)Activator.CreateInstance(type);
                    this.SkillBonus = (Bonus)Activator.CreateInstance(type);
                    this.ChanceOfCriticalHit = (Bonus)Activator.CreateInstance(type); this.DamageToMonsterType = (Bonus)Activator.CreateInstance(type);
                    this.AllSkillsBonus = (Bonus)Activator.CreateInstance(type);

                    this.Damage.Value = this.random.Next(WeaponConstants.RareScepterMaxDamageBonus, WeaponConstants.LegendaryScepterMaxDamageBonus);

                    this.DamageToMonsterType.Value = WeaponConstants.LegendaryWeaponMonsterTypeDamageBonus;
                    this.DamageToMonsterType.Description = String.Concat(BonusConstants.Plus,
                        this.DamageToMonsterType.Value.ToString(), BonusConstants.DamageToMonsterTypeDesc,
                        (MonsterType)this.random.Next(GlobalConstants.EnumMinValue, GlobalConstants.MonsterTypeEnumMaxValue));

                    this.SkillBonus.Value = WeaponConstants.RareWeaponSkillBonusValue;
                    this.SkillBonus.Description = String.Concat(this.SkillBonus.Value.ToString(),
                        BonusConstants.To, BonusConstants.ScepterSkillBonuses[random.Next(0, BonusConstants.ScepterSkillBonuses.Count - 1)]);

                    this.ChanceOfCriticalHit.Value = random.Next(WeaponConstants.ScepterMinChanceOfCriticalHit, WeaponConstants.ScepterMaxChanceOfCriticalHit);
                    this.ChanceOfCriticalHit.Description = String.Concat(BonusConstants.ChanceOfCriticalHit,
                        this.ChanceOfCriticalHit.Value.ToString(), BonusConstants.Percentage);

                    this.IgnoreTargetsDefense = true;

                    this.AllSkillsBonus.Value = this.random.Next(WeaponConstants.AllSkillsMinBonusValue, WeaponConstants.AllSkillsMaxBonusValue);
                    this.AllSkillsBonus.Description = String.Concat(this.AllSkillsBonus.Value.ToString(), BonusConstants.AllSkillsDesc);

                    this.Bonuses.Add(AllSkillsBonus);
                    this.Bonuses.Add(SkillBonus);
                    this.Bonuses.Add(ChanceOfCriticalHit);
                    this.Bonuses.Add(DamageToMonsterType);
                    break;

                default:
                    throw new ArgumentException(ExceptionMessages.NoSuchItemTypeMessage);
            }

            this.Accuracy.Value = this.random.Next(WeaponConstants.ScepterMinAccuracy, WeaponConstants.WeaponMaxAccuracy);
            this.Accuracy.Description = String.Concat(BonusConstants.AccuracyBonusDesc, this.Accuracy.Value.ToString());
            this.Damage.Description = String.Concat(BonusConstants.DamageBonusDesc, this.Damage.Value.ToString());

            this.Name = String.Concat(itemType, " ", typeof(Scepter).Name, ItemConstants.weaponNames[random.Next(0, ItemConstants.weaponNames.Count - 1)]);

            this.Bonuses.Add(Accuracy);
            this.Bonuses.Add(Damage);
        }
    }
}
