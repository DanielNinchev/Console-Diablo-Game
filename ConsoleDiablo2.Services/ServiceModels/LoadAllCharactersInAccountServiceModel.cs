using ConsoleDiablo2.DataModels;

using System;
using System.Collections.Generic;

namespace ConsoleDiablo2.Services.ServiceModels
{
    public class LoadAllCharactersInAccountServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Experience { get; set; }

        public byte Level { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DateCreated { get; set; }

        public double LifeRegenerator { get; set; }

        public int BaseMana { get; set; }

        public int Mana { get; set; }

        public double ManaRegenerator { get; set; }

        public int GoldCoins { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int GearId { get; set; }
        public virtual Gear Gear { get; set; }
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }

        public bool HasLeveledUp { get; set; }

        public int ChanceOfCriticalHit { get; set; }

        public int LifeTap { get; set; }

        public int ManaTap { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
