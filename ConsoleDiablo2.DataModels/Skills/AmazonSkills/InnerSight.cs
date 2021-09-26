using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Skills.Contracts;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AmazonSkills
{
    public class InnerSight : Skill, IAffectableSkill
    {
        public InnerSight()
        {
            this.Name = AmazonSkillConstants.InnerSightName;
            this.RequiredLevel = AmazonSkillConstants.InnerSightRequiredLevel;
            this.RequiredSkill = AmazonSkillConstants.InnerSightRequiredSkill;
            this.FirstLevelValue = AmazonSkillConstants.InnerSightFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AmazonSkillDescriptions);
            this.IsPassive = true;
        }

        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            character.Defense += (int)(this.FirstLevelValue * AmazonSkillConstants.InnerSightDefenseValue);

            if (character.Skills.Any(s => s.Name == AmazonSkillConstants.DodgeName && s.IsDeveloped))
            {
                character.Defense += (int)(this.FirstLevelValue * AmazonSkillConstants.InnerSightDodgeBonus);
            }
        }

        public override void UnaffectCharacter(Character character)
        {
        }
    }
}
