using ConsoleDiablo2.DataModels.Monsters.Contracts;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.Common;

namespace ConsoleDiablo2.DataModels.Monsters
{
    public class Arachnid : Monster, IArachnid
    {
        public Arachnid(Character character) : base(character)
        {
            this.Infect = new Bonus((int)this.Type, MonsterConstants.InfectDescription);
        }

        public Bonus Infect { get; set; }

        public override void UnaffectCharacter(Character character)
        {
        }

        public override void UseSpecialAbility(Character character)
        {
            this.DamageType = DamageType.Poison;
            this.Damage += character.Level * this.Infect.Value;
        }
    }
}
