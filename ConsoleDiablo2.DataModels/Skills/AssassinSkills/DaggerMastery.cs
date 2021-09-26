using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Items.Weapons;
using ConsoleDiablo2.DataModels.Skills.Contracts;
using System;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AssassinSkills
{
    public class DaggerMastery : Skill
    {
        public DaggerMastery()
        {
            this.Name = AssassinSkillConstants.DaggerMasteryName;
            this.RequiredLevel = AssassinSkillConstants.DaggerMasteryRequiredLevel;
            this.RequiredSkill = AssassinSkillConstants.DaggerMasteryRequiredSkill;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AssassinSkillDescriptions);
            this.IsPassive = true;
        }

        public override void AffectCharacter(Character character)
        {
            foreach (var item in character.Gear.Items)
            {
                if (item is Dagger)
                {
                    Dagger dagger = (Dagger)item;

                    if (dagger.Gear.Character != null)
                    {
                        if (dagger.Gear.Character.Skills.Any(sk => sk.GetType() == typeof(DaggerMastery) && sk.IsDeveloped))
                        {
                            dagger.Gear.Character.Damage += (int)(dagger.Damage.Value * AssassinSkillConstants.DaggerMasteryValue);
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
