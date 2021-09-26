using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Monsters.Contracts;

namespace ConsoleDiablo2.DataModels
{
    public abstract class Being : IBeing
    {
        public Being()
        {
            this.IsAlive = true;
            this.IsPoisoned = false;
        }

        public double Damage { get; set; }

        public DamageType DamageType { get; set; }

        public double Life { get; set; }

        public double BaseLife { get; set; }

        public double LifeRegenerator { get; set; }

        public double Defense { get; set; }

        public double FireResistance { get; set; }
               
        public double ColdResistance { get; set; }
              
        public double LightningResistance { get; set; }
               
        public double PoisonResistance { get; set; }

        public bool IsAlive { get; set; }

        public bool IsPoisoned { get; set; }

        public bool IsFrozen { get; set; }

        public void BeingPoisoned(double damage)
        {
            if (this.IsPoisoned)
            {
                this.Life -= damage;
                this.LifeRegenerator = 0;
            }
        }
    }
}
