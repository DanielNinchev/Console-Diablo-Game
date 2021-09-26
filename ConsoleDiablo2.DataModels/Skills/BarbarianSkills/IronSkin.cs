using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Skills.Contracts;

namespace ConsoleDiablo2.DataModels.Skills.BarbarianSkills
{
    public class IronSkin : Skill, IAffectableSkill
    {
        public IronSkin()
        {
            this.Name = BarbarianSkillConstants.IronSkinName;
            this.RequiredLevel = BarbarianSkillConstants.IronSkinRequiredLevel;
            this.RequiredSkill = BarbarianSkillConstants.IronSkinRequiredSkill;
            this.FirstLevelValue = BarbarianSkillConstants.IronSkinFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.BarbarianSkillDescriptions);
            this.IsPassive = true;
        }

        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.Level > 1)
            {
                this.FirstLevelValue += (int)(this.FirstLevelValue * BarbarianSkillConstants.IronSkinDefenseValue);
            }

            character.Defense += this.FirstLevelValue;
        }

        public override void UnaffectCharacter(Character character)
        {
        }
    }
}
