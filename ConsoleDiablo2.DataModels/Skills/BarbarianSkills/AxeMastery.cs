using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Items.Weapons;

using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.BarbarianSkills
{
    public class AxeMastery : Skill
    {
        public AxeMastery()
        {
            this.Name = BarbarianSkillConstants.AxeMasteryName;
            this.RequiredLevel = BarbarianSkillConstants.AxeMasteryRequiredLevel;
            this.RequiredSkill = BarbarianSkillConstants.AxeMasteryRequiredSkill;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.BarbarianSkillDescriptions);
            this.IsPassive = true;
        }

        public override void AffectCharacter(Character character)
        {
            foreach (var item in character.Gear.Items)
            {
                if (item is Axe)
                {
                    Axe axe = (Axe)item;

                    if (axe.Gear.Character != null)
                    {
                        if (axe.Gear.Character.Skills.Any(sk => sk.GetType() == typeof(AxeMastery) && sk.IsDeveloped))
                        {
                            axe.Gear.Character.Damage += (int)(axe.Damage.Value * BarbarianSkillConstants.AxeMasteryDamageValue);
                        }
                    }
                }
            }
        }

        public override void UnaffectCharacter(Character character)
        {
        }
    }
}
