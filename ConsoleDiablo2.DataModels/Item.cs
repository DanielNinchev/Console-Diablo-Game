using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Items.Contracts;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ConsoleDiablo2.DataModels
{
    public abstract class Item : IItem
    {
        public Item()
        {
            this.Bonuses = new HashSet<Bonus>();
        }

        public Item(
            int id, 
            ItemClass itemClass, 
            string name, 
            int size, 
            int sellValue,
            Bonus skillBonus,
            Bonus allSkillsBonus,
            Gear gear,
            Inventory inventory,
            HashSet<Bonus> bonuses)
        {
            this.Id = id;
            this.Class = itemClass;
            this.Name = name;
            this.Size = size;
            this.SellValue = sellValue;
            this.SkillBonus = skillBonus;
            this.AllSkillsBonus = allSkillsBonus;
            this.Gear = gear;
            this.Inventory = inventory;
            this.Bonuses = bonuses;
        }

        [Key]
        public int Id { get; set; }

        public ItemClass Class { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public int SellValue { get; set; }

        public Bonus SkillBonus { get; set; }

        public Bonus AllSkillsBonus { get; set; }

        [ForeignKey(nameof(Gear))]
        public int? GearId { get; set; }
        public virtual Gear Gear { get; set; }

        [ForeignKey(nameof(Inventory))]
        public int? InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }

        public virtual ICollection<Bonus> Bonuses { get; set; }

        public abstract void AffectCharacter();

        public abstract void UnaffectCharacter();

        public void AffectCharacterWithSkillBonus(Character character)
        {
            if (this.SkillBonus != null)
            {
                foreach (var skill in this.Gear.Character.Skills)
                {
                    if (this.SkillBonus.Description.Contains(skill.Name))
                    {
                        skill.Level += (byte)this.SkillBonus.Value;
                            
                        if (skill.Level > 0 && !skill.IsDeveloped)
                        {
                            skill.IsDeveloped = true;

                            if (skill.IsPassive)
                            {
                                skill.IsActivated = true;
                                skill.AffectCharacter(character);
                            }
                        }

                        break;
                    }
                }
            }
        }

        public void AffectCharacterWithAllSkillsBonus(Character character)
        {
            if (this.AllSkillsBonus != null)
            {
                foreach (var skill in this.Gear.Character.Skills)
                {
                    skill.Level += (byte)this.AllSkillsBonus.Value;

                    if (skill.Level > 0 && !skill.IsDeveloped)
                    {
                        skill.IsDeveloped = true;

                        if (skill.IsPassive)
                        {
                            skill.IsActivated = true;
                            skill.AffectCharacter(character);
                        }
                    }
                }
            }
        }

        public ItemClass DrawItemClass(MonsterRank monsterRank)
        {
            Random random = new Random();

            List<ItemClass> prizes = GetItemClassList(monsterRank);

            ItemClass classOfPrize = prizes[random.Next(0, prizes.Count())];

            return classOfPrize;
        }

        public List<ItemClass> GetItemClassList(MonsterRank monsterRank)
        {
            List<ItemClass> prizeList = new List<ItemClass>();
            ItemClass lowestDropableItemClass = 0;

            switch (monsterRank)
            {
                case MonsterRank.Ordinary:
                    lowestDropableItemClass = ItemClass.Ordinary;
                    break;
                case MonsterRank.Strong:
                    lowestDropableItemClass = ItemClass.Superior;
                    break;
                case MonsterRank.Champion:
                    lowestDropableItemClass = ItemClass.Magic;
                    break;
                case MonsterRank.Legendary:
                    lowestDropableItemClass = ItemClass.Rare;
                    break;
                case MonsterRank.Boss:
                    lowestDropableItemClass = ItemClass.Legendary;
                    break;
            }

            for (int i = (int)ItemClass.Legendary; i <= (int)lowestDropableItemClass; i++)
            {
                for (int j = i; j <= Math.Pow(i, i); j++)
                {
                    prizeList.Add((ItemClass)i);
                }
            }

            return prizeList;
        }

        public abstract void InitializeItemBonuses(ItemClass itemType);

        public List<string> InitializeItemDescription()
        {
            List<string> description = new List<string>();

            foreach (var bonus in this.Bonuses)
            {
                description.Add(bonus.Description);
            }

            return description;
        }

        public void UnaffectCharacterWithSkillBonus(Character character)
        {
            if (this.SkillBonus != null)
            {
                foreach (var skill in this.Gear.Character.Skills)
                {
                    if (this.SkillBonus.Description.Contains(skill.Name))
                    {
                        skill.Level -= (byte)this.SkillBonus.Value;

                        if (skill.Level == 0)
                        {
                            skill.IsDeveloped = false;

                            if (skill.IsPassive)
                            {
                                skill.IsActivated = false;
                                skill.UnaffectCharacter(character);
                            }
                        }

                        break;
                    }
                }
            }
        }

        public void UnaffectCharacterWithAllSkillsBonus(Character character)
        {
            if (this.AllSkillsBonus != null)
            {
                foreach (var skill in this.Gear.Character.Skills)
                {
                    skill.Level -= (byte)this.AllSkillsBonus.Value;

                    if (skill.Level == 0)
                    {
                        skill.IsDeveloped = false;

                        if (skill.IsPassive)
                        {
                            skill.IsActivated = false;
                            skill.UnaffectCharacter(character);
                        }
                    }
                }
            }
        }
    }
}