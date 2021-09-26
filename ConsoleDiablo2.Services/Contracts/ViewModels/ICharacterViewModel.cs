using ConsoleDiablo2.DataModels;

using System;

namespace ConsoleDiablo2.Services.Contracts.ViewModels
{
    public interface ICharacterViewModel
    {
        string Name { get; set; }

        string Type { get; set; }

        double Experience { get; set; }

        byte Level { get; set; }

        DateTime DateCreated { get; set; }

        int Damage { get; set; }

        int Defense { get; set; }

        int BaseLife { get; set; }

        int Life { get; set; }

        int BaseMana { get; set; }

        int Mana { get; set; }

        int FireResistance { get; set; }

        int ColdResistance { get; set; }

        int LightningResistance { get; set; }

        int PoisonResistance { get; set; }

        int GoldCoins { get; set; }

        Account Account { get; set; }
    }
}
