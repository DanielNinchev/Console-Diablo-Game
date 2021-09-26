using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Enums;

using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AssassinSkills
{
    public class Venom : Skill
    {
        public Venom()
        {
            this.Name = AssassinSkillConstants.VenomName;
            this.RequiredLevel = AssassinSkillConstants.VenomRequiredLevel;
            this.RequiredSkill = AssassinSkillConstants.VenomRequiredSkill;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AssassinSkillDescriptions);
            this.IsPassive = true;
        }

        public override void AffectCharacter(Character character)
        {
            foreach (var skill in character.Skills.Where(s => s.Description.Contains("[Martial Art]")))
            {
                double unaffectedDamage = character.Damage;

                if (skill.IsActivated)
                {
                    character.Damage += (int)(unaffectedDamage * this.Level * AssassinSkillConstants.VenomValue);
                    character.DamageType = DamageType.Poison;
                }
            }
        }

        public override void UnaffectCharacter(Character character)
        {
            foreach (var skill in character.Skills.Where(s => s.Description[1].Contains("[Martial Art]")))
            {
                double unaffectedDamage = character.Damage;

                if (!skill.IsActivated)
                {
                    character.Damage -= (int)(unaffectedDamage * this.Level * AssassinSkillConstants.VenomValue);
                    character.DamageType = DamageType.Physical;
                }
            }
        }
    }
}
