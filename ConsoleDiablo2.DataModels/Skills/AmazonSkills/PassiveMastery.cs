using ConsoleDiablo2.Common.SkillConstants;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AmazonSkills
{
    public class PassiveMastery : Skill
    {
        public PassiveMastery()
        {
            this.Name = AmazonSkillConstants.PassiveMasteryName;
            this.RequiredLevel = AmazonSkillConstants.PassiveMasteryRequiredLevel;
            this.RequiredSkill = AmazonSkillConstants.PassiveMasteryRequiredSkill;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AmazonSkillDescriptions);
            this.IsPassive = true;
        }

        public override void AffectCharacter(Character character)
        {
            foreach (var skill in character.Skills.Where(s => s.IsPassive && s.IsDeveloped))
            {
                skill.Level += AmazonSkillConstants.PassiveMasteryValue;
                skill.AffectCharacter(character);
            }
        }

        public override void UnaffectCharacter(Character character)
        {
        }
    }
}
