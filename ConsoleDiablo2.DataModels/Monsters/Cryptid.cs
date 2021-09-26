using ConsoleDiablo2.Common;
using ConsoleDiablo2.DataModels.Monsters.Contracts;

using System;

namespace ConsoleDiablo2.DataModels.Monsters
{
    public class Cryptid : Monster, ICryptid
    {
        public Cryptid(Character character) : base(character)
        {
            this.DrainMana = new Bonus((int)this.Type, MonsterConstants.DrainManaDescription);
            this.Monstrosity = new Bonus((int)this.Type, MonsterConstants.MonstrosityDescription);
        }

        public Bonus DrainMana { get; set; }

        public Bonus Monstrosity { get; set; }

        public override void UnaffectCharacter(Character character)
        {
            if (this.HasAffectedCharacter)
            {
                character.Mana += character.Level * this.DrainMana.Value;
            }           
        }

        public override void UseSpecialAbility(Character character)
        {
            character.Mana = Math.Max(character.Mana - character.Level * this.DrainMana.Value, 0);

            this.HasAffectedCharacter = true;
            this.Damage += character.Level * Monstrosity.Value;
        }
    }
}
