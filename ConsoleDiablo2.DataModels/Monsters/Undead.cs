using ConsoleDiablo2.Common;
using ConsoleDiablo2.DataModels.Monsters.Contracts;

namespace ConsoleDiablo2.DataModels.Monsters
{
    public class Undead : Monster, IUndead
    {
        public Undead(Character character) : base(character)
        {
            this.Revitalization = new Bonus((int)this.Type, MonsterConstants.RevitalizationDescription);
            this.Painlessness = new Bonus((int)this.Type, MonsterConstants.PainlessnessDescription);
        }

        public Bonus Revitalization { get; set; }

        public Bonus Painlessness { get; set; }

        public override void UnaffectCharacter(Character character)
        {
        }

        public override void UseSpecialAbility(Character character)
        {
            this.Life += this.Revitalization.Value * character.Level;
            this.Defense += this.Painlessness.Value * character.Level;
        }
    }
}
