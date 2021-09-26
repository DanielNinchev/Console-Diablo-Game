using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Items.Weapons;
using ConsoleDiablo2.DataModels.Skills.Contracts;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AssassinSkills
{
    public class FireDagger : Skill, IAffectableSkill
    {
        public FireDagger()
        {
            this.Name = AssassinSkillConstants.FireDaggerName;
            this.RequiredLevel = AssassinSkillConstants.FireDaggerRequiredLevel;
            this.RequiredSkill = AssassinSkillConstants.FireDaggerRequiredSkill;
            this.ManaCost = AssassinSkillConstants.FireDaggerManaCost;
            this.FirstLevelValue = AssassinSkillConstants.FireDaggerFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AssassinSkillDescriptions);
        }

        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped == true && this.IsActivated == true && character.Gear.Items.Any(i => i.GetType() == typeof(Dagger)))
            {
                this.CheckCharacterMana(character);

                character.DamageType = DamageType.Fire;
                character.Damage += (int)(this.FirstLevelValue * AssassinSkillConstants.FireDaggerDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AssassinSkillConstants.ShockWebName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AssassinSkillConstants.FireDaggerShockWebBonusValue * skill.Level);
                    }
                    if (skill.Name == AssassinSkillConstants.ExplosiveDaggerName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AssassinSkillConstants.FireDaggerExplosiveDaggerBonusValue * skill.Level);
                    }
                }
            }
        }

        public override void UnaffectCharacter(Character character)
        {
            if (this.IsActivated)
            {
                this.IsActivated = false;

                character.DamageType = DamageType.Physical;
                character.Damage -= (int)(this.FirstLevelValue * AssassinSkillConstants.FireDaggerDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AssassinSkillConstants.ShockWebName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AssassinSkillConstants.FireDaggerShockWebBonusValue * skill.Level);
                    }
                    if (skill.Name == AssassinSkillConstants.ExplosiveDaggerName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AssassinSkillConstants.FireDaggerExplosiveDaggerBonusValue * skill.Level);
                    }
                }
            }
        }
    }
}
