using ConsoleDiablo2.Common;
using ConsoleDiablo2.DataModels.Monsters.Contracts;
using ConsoleDiablo2.DataModels.Enums;

using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleDiablo2.DataModels.Monsters
{
    public class Demon : Monster, IDemon
    {
        //private Queue<int> oldSkillLevels = new Queue<int>();

        public Demon(Character character) : base(character)
        {
            this.Immolation = new Bonus((int)this.Type, MonsterConstants.ImmolationDescription);
            this.Paranormality = new Bonus((int)this.Type, MonsterConstants.ParanormalityDescription);
        }

        public Bonus Immolation { get; set; }

        public Bonus Paranormality { get; set; }

        public override void UseSpecialAbility(Character character)
        {
            this.HasAffectedCharacter = true;
            this.FireResistance = GlobalConstants.MaxResistanceValue;

            this.Damage += this.Immolation.Value * character.Level;
            this.DamageType = DamageType.Fire;

            //foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
            //{
            //    if (skill.Level > 1)
            //    {
            //        oldSkillLevels.Enqueue(skill.Level);
            //        skill.Level = Math.Max(skill.Level - this.Paranormality.Value, 1);
            //    }
            //}
        }

        public override void UnaffectCharacter(Character character)
        {
            if (this.HasAffectedCharacter)
            {
                //foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                //{
                //    if (oldSkillLevels.Count > 0)
                //    {
                //        skill.Level = oldSkillLevels.Dequeue();
                //    }
                //}
            }       
        }
    }
}
