using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Items.Weapons;

using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AmazonSkills
{
    public class SpearMastery : Skill
    {
        public SpearMastery()
        {
            this.Name = AmazonSkillConstants.SpearMasteryName;
            this.RequiredLevel = AmazonSkillConstants.SpearMasteryRequiredLevel;
            this.RequiredSkill = AmazonSkillConstants.SpearMasteryRequiredSkill;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AmazonSkillDescriptions);
            this.IsPassive = true;
        }

        public override void AffectCharacter(Character character)
        {
            foreach (var item in character.Gear.Items)
            {
                if (item is Spear)
                {
                    Spear spear = (Spear)item;

                    if (spear.Gear.Character != null)
                    {
                        if (spear.Gear.Character.Skills.Any(sk => sk.GetType() == typeof(SpearMastery) && sk.IsDeveloped))
                        {
                            spear.Gear.Character.Damage += (int)(spear.Damage.Value * AmazonSkillConstants.SpearMasteryDamageValue);
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
