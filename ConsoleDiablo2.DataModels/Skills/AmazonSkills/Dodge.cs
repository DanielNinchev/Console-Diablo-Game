using ConsoleDiablo2.Common.SkillConstants;

using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AmazonSkills
{
    public class Dodge : Skill
    {
        public Dodge()
        {
            this.Name = AmazonSkillConstants.DodgeName;
            this.RequiredLevel = AmazonSkillConstants.DodgeRequiredLevel;
            this.RequiredSkill = AmazonSkillConstants.DodgeRequiredSkill;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AmazonSkillDescriptions);
            this.IsPassive = true;
        }

        public override void AffectCharacter(Character character)
        {
            character.ChanceToBlock += AmazonSkillConstants.DodgeValue;

            if (character.Skills.Any(s => s.Name == AmazonSkillConstants.InnerSightName && s.IsDeveloped))
            {
                character.ChanceToBlock += AmazonSkillConstants.DodgeInnerSightBonusValue;
            }
        }

        public override void UnaffectCharacter(Character character)
        {
        }
    }
}
