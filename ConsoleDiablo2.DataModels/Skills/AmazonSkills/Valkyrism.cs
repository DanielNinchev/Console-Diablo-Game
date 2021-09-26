using ConsoleDiablo2.Common.SkillConstants;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AmazonSkills
{
    public class Valkyrism : Skill
    {
        public Valkyrism()
        {
            this.Name = AmazonSkillConstants.ValkyrismName;
            this.RequiredLevel = AmazonSkillConstants.ValkyrismRequiredLevel;
            this.RequiredSkill = AmazonSkillConstants.ValkyrismRequiredSkill;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AmazonSkillDescriptions);
            this.IsPassive = true;
        }

        public override void AffectCharacter(Character character)
        {
            foreach (var skill in character.Skills.Where(s => !s.IsPassive && s.IsDeveloped))
            {
                skill.Level += AmazonSkillConstants.ValkyrismValue * this.Level;
            }
        }

        public override void UnaffectCharacter(Character character)
        {
        }
    }
}
