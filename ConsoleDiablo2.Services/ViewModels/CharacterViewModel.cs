using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.Services.Contracts.ViewModels;

using System;

namespace ConsoleDiablo2.Services.ViewModels
{
    public class CharacterViewModel : ICharacterViewModel
    {
        public string Name { get; set; }
        
        public string Type { get; set; }

        public double Experience { get; set; }

        public byte Level { get; set; }

        public DateTime DateCreated { get; set; }

        public int Damage { get; set; }

        public int ChanceOfCriticalHit { get; set; }

        public int Defense { get; set; }

        public int BaseLife { get; set; }

        public int Life { get; set; }

        public int BaseMana { get; set; }

        public int Mana { get; set; }

        public int FireResistance { get; set; }

        public int ColdResistance { get; set; }

        public int LightningResistance { get; set; }

        public int PoisonResistance { get; set; }

        public int GoldCoins { get; set; }

        public Account Account { get; set; }
    }
}
