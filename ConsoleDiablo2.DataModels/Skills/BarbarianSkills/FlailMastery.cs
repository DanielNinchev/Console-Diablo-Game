using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Items.Weapons;

using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.BarbarianSkills
{
    public class FlailMastery : Skill
    {
        public FlailMastery()
        {
            this.Name = BarbarianSkillConstants.FlailMasteryName;
            this.RequiredLevel = BarbarianSkillConstants.FlailMasteryRequiredLevel;
            this.RequiredSkill = BarbarianSkillConstants.FlailMasteryRequiredSkill;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.BarbarianSkillDescriptions);
            this.IsPassive = true;
        }

        public override void AffectCharacter(Character character)
        {
            foreach (var item in character.Gear.Items)
            {
                if (item is Flail)
                {
                    Flail flail = (Flail)item;

                    if (flail.Gear.Character != null)
                    {
                        if (flail.Gear.Character.Skills.Any(sk => sk.GetType() == typeof(FlailMastery) && sk.IsDeveloped))
                        {
                            flail.Gear.Character.Damage += (int)(flail.Damage.Value * BarbarianSkillConstants.FlailMasteryDamageValue);
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
