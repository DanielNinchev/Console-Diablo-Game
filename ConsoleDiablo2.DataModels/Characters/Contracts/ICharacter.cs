using ConsoleDiablo2.DataModels.Contracts;
using ConsoleDiablo2.DataModels.SkillTrees;
using System;
using System.Collections.Generic;

namespace ConsoleDiablo2.DataModels.Characters.Contracts
{
    public interface ICharacter : IEntity
    {
        int Id { get; set; }
        string Name { get; set; }

        double Experience { get; set; }
        byte Level { get; set; }

        int SkillPoints { get; set; }
        int StatusPoints { get; set; }

        bool IsDeleted { get; set; }
        DateTime DateCreated { get; set; }
        bool HasLeveledUp { get; set; }

        double LifeRegenerator { get; set; }

        double BaseMana { get; set; }
        double Mana { get; set; }
        double ManaRegenerator { get; set; }

        int GoldCoins { get; set; }

        int AccountId { get; set; }
        Account Account { get; set; }

        int GearId { get; set; }
        Gear Gear { get; set; }

        int InventoryId { get; set; }
        Inventory Inventory { get; set; }

        ICollection<Skill> Skills { get; set; }

        Tree<string> SkillTree { get; set; }
    }
}
