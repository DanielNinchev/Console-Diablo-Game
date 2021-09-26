using ConsoleDiablo2.Common.SkillConstants;

namespace ConsoleDiablo2.DataModels.Skills.BarbarianSkills
{
    public class NaturalResistance : Skill
    {
        public NaturalResistance()
        {
            this.Name = BarbarianSkillConstants.NaturalResistanceName;
            this.RequiredSkill = BarbarianSkillConstants.NaturalResistanceRequiredSkill;
            this.RequiredLevel = BarbarianSkillConstants.NaturalResistanceRequiredLevel;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.BarbarianSkillDescriptions);
            this.IsPassive = true;
        }

        public override void AffectCharacter(Character character)
        {
            character.FireResistance += BarbarianSkillConstants.NaturalResistanceValue;
            character.LightningResistance += BarbarianSkillConstants.NaturalResistanceValue;
            character.ColdResistance += BarbarianSkillConstants.NaturalResistanceValue;
            character.PoisonResistance += BarbarianSkillConstants.NaturalResistanceValue;
        }

        public override void UnaffectCharacter(Character character)
        {
        }
    }
}
