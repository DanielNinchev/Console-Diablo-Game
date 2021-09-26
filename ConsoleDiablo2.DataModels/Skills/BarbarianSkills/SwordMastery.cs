using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Items.Weapons;

using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.BarbarianSkills
{
    public class SwordMastery : Skill
    {
        public SwordMastery()
        {
            this.Name = BarbarianSkillConstants.SwordMasteryName;
            this.RequiredLevel = BarbarianSkillConstants.SwordMasteryRequiredLevel;
            this.RequiredSkill = BarbarianSkillConstants.SwordMasteryRequiredSkill;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.BarbarianSkillDescriptions);
            this.IsPassive = true;
        }

        public override void AffectCharacter(Character character)
        {
            foreach (var item in character.Gear.Items)
            {
                if (item is Sword)
                {
                    Sword sword = (Sword)item;

                    if (sword.Gear.Character != null)
                    {
                        if (sword.Gear.Character.Skills.Any(sk => sk.GetType() == typeof(SwordMastery) && sk.IsDeveloped))
                        {
                            sword.Gear.Character.Damage += (int)(sword.Damage.Value * BarbarianSkillConstants.SwordMasteryDamageValue);
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
