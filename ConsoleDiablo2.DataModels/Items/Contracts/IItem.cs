using ConsoleDiablo2.DataModels.Enums;
using System.Collections.Generic;

namespace ConsoleDiablo2.DataModels.Items.Contracts
{
    public interface IItem
    {
        int Id { get; set; }

        ItemClass Class { get; set; }

        string Name { get; set; }

        int Size { get; set; }

        int SellValue { get; set; }

        int? GearId { get; set; }

        Gear Gear { get; set; }

        int? InventoryId { get; set; }

        Inventory Inventory { get; set; }

        ICollection<Bonus> Bonuses { get; set; }

        void AffectCharacter();

        void AffectCharacterWithSkillBonus(Character character);

        void AffectCharacterWithAllSkillsBonus(Character character);

        void InitializeItemBonuses(ItemClass item);

        void UnaffectCharacter();

        void UnaffectCharacterWithSkillBonus(Character character);

        void UnaffectCharacterWithAllSkillsBonus(Character character);
    }
}
