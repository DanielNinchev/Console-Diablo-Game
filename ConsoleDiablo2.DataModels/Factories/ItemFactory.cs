using ConsoleDiablo2.Common;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Factories.Contracts;
using ConsoleDiablo2.DataModels.Items.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleDiablo2.DataModels.Factories
{
    public class ItemFactory : IItemFactory
    {
        public Item CreateItem(string type)
        {
            var itemType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(it => it.Name == type);

            if (itemType == null)
            {
                throw new ArgumentNullException(ExceptionMessages.NoSuchItemTypeMessage);
            }

            if (!typeof(IItem).IsAssignableFrom(itemType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ThisIsNotAnItemType));
            }

            var item = (Item)Activator.CreateInstance(itemType);

            return item;
        }

        public Item LoadItem(string type, int id,
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
            var itemType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(it => it.Name == type);

            if (itemType == null)
            {
                throw new ArgumentNullException(ExceptionMessages.NoSuchItemTypeMessage);
            }

            if (!typeof(IItem).IsAssignableFrom(itemType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ThisIsNotAnItemType));
            }

            var item = (Item)Activator.CreateInstance(itemType, id, itemClass, name, size, sellValue, 
                skillBonus, allSkillsBonus, gear, inventory, bonuses);

            return item;
        }
    }
}
