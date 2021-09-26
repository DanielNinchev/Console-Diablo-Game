using ConsoleDiablo2.Common.SkillConstants;

namespace ConsoleDiablo2.DataModels.Skills.AmazonSkills
{
    public class CriticalStrike : Skill
    {
        public CriticalStrike()
        {
            this.Name = AmazonSkillConstants.CriticalStrikeName;
            this.RequiredLevel = AmazonSkillConstants.CriticalStrikeRequiredLevel;
            this.RequiredSkill = AmazonSkillConstants.CriticalStrikeRequiredSkill;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AmazonSkillDescriptions);
            this.IsPassive = true;
        }

        public override void AffectCharacter(Character character)
        {
            character.ChanceOfCriticalHit += AmazonSkillConstants.CriticalStrikeValue;
        }

        public override void UnaffectCharacter(Character character)
        {
        }
    }
}
