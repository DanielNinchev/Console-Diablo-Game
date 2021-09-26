using ConsoleDiablo2.DataModels.Enums;
using System.Collections.Generic;

namespace ConsoleDiablo2.DataModels.Factories.Contracts
{
    public interface IItemFactory
    {
        Item CreateItem(string type);

        Item LoadItem(string type, 
            int id,
            ItemClass itemClass,
            string name,
            int size,
            int sellValue,
            Bonus skillBonus,
            Bonus allSkillsBonus,
            Gear gear,
            Inventory inventory,
            HashSet<Bonus> bonuses);
    }
}
