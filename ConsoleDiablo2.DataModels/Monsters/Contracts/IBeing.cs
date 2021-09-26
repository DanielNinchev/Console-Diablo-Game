using ConsoleDiablo2.DataModels.Enums;

namespace ConsoleDiablo2.DataModels.Monsters.Contracts
{
    public interface IBeing
    {
        double Damage { get; set; }

        DamageType DamageType { get; set; }

        double Life { get; set; }

        double BaseLife { get; set; }

        double Defense { get; set; }

        double FireResistance { get; set; }

        double ColdResistance { get; set; }

        double LightningResistance { get; set; }

        double PoisonResistance { get; set; }

        bool IsAlive { get; set; }

        bool IsFrozen { get; set; }

        bool IsPoisoned { get; set; }
    }
}