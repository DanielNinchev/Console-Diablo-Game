using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Skills.Contracts;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AssassinSkills
{
    public class DeathSentry : Skill, IAffectableSkill
    {
        public DeathSentry()
        {
            this.Name = AssassinSkillConstants.DeathSentryName;
            this.RequiredLevel = AssassinSkillConstants.DeathSentryRequiredLevel;
            this.RequiredSkill = AssassinSkillConstants.DeathSentryRequiredSkill;
            this.ManaCost = AssassinSkillConstants.DeathSentryManaCost;
            this.FirstLevelValue = AssassinSkillConstants.DeathSentryFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AssassinSkillDescriptions);
        }

        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped == true && this.IsActivated == true)
            {
                this.CheckCharacterMana(character);

                character.DamageType = DamageType.Lightning;
                character.Damage += (int)(this.FirstLevelValue * AssassinSkillConstants.DeathSentryDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AssassinSkillConstants.ShockWebName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AssassinSkillConstants.DeathSentryShockWebBonusValue * skill.Level);
                    }
                    if (skill.Name == AssassinSkillConstants.LightningSentryName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AssassinSkillConstants.DeathSentryLightningSentryBonusValue * skill.Level);
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
                character.Damage -= (int)(this.FirstLevelValue * AssassinSkillConstants.DeathSentryDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AssassinSkillConstants.ShockWebName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AssassinSkillConstants.DeathSentryShockWebBonusValue * skill.Level);
                    }
                    if (skill.Name == AssassinSkillConstants.LightningSentryName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AssassinSkillConstants.DeathSentryLightningSentryBonusValue * skill.Level);
                    }
                }
            }
        }
    }
}
