using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Enums;

using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AssassinSkills
{
    public class MartialArts : Skill
    {
        public MartialArts()
        {
            this.Name = AssassinSkillConstants.MartialArtsName;
            this.RequiredLevel = AssassinSkillConstants.MartialArtsRequiredLevel;
            this.RequiredSkill = AssassinSkillConstants.MartialArtsRequiredSkill;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AssassinSkillDescriptions);
            this.IsPassive = true;
        }

        public override void AffectCharacter(Character character)
        {
            foreach (var skill in character.Skills.Where(s => s.Description[1].Contains("[Martial Art]")))
            {
                if (skill.IsDeveloped)
                {
                    skill.Level += AssassinSkillConstants.MartialArtsValue;
                }
            }
        }

        public override void UnaffectCharacter(Character character)
        {
        }
    }
}
