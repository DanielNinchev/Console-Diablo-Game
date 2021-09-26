using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Skills.Contracts;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AssassinSkills
{
    public class LightningSentry : Skill, IAffectableSkill
    {
        public LightningSentry()
        {
            this.Name = AssassinSkillConstants.LightningSentryName;
            this.RequiredLevel = AssassinSkillConstants.LightningSentryRequiredLevel;
            this.RequiredSkill = AssassinSkillConstants.LightningSentryRequiredSkill;
            this.ManaCost = AssassinSkillConstants.LightningSentryManaCost;
            this.FirstLevelValue = AssassinSkillConstants.LightningSentryFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AssassinSkillDescriptions);
        }

        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped == true && this.IsActivated == true)
            {
                this.CheckCharacterMana(character);

                character.DamageType = DamageType.Lightning;
                character.Damage += (int)(this.FirstLevelValue * AssassinSkillConstants.LightningSentryDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AssassinSkillConstants.ShockWebName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AssassinSkillConstants.LightningSentryShockWebBonusValue * skill.Level);
                    }
                    if (skill.Name == AssassinSkillConstants.DeathSentryName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AssassinSkillConstants.LightningSentryDeathSentryBonusValue * skill.Level);
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
                character.Damage -= (int)(this.FirstLevelValue * AssassinSkillConstants.LightningSentryDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AssassinSkillConstants.ShockWebName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AssassinSkillConstants.LightningSentryShockWebBonusValue * skill.Level);
                    }
                    if (skill.Name == AssassinSkillConstants.DeathSentryName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AssassinSkillConstants.LightningSentryDeathSentryBonusValue * skill.Level);
                    }
                }
            }
        }
    }
}
