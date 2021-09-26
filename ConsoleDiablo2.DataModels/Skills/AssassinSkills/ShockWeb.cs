using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Skills.Contracts;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AssassinSkills
{
    public class ShockWeb : Skill, IAffectableSkill
    {
        public ShockWeb()
        {
            this.Name = AssassinSkillConstants.ShockWebName;
            this.RequiredLevel = AssassinSkillConstants.ShockWebRequiredLevel;
            this.RequiredSkill = AssassinSkillConstants.ShockWebRequiredSkill;
            this.ManaCost = AssassinSkillConstants.ShockWebManaCost;
            this.FirstLevelValue = AssassinSkillConstants.ShockWebFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AssassinSkillDescriptions);
        }

        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped == true && this.IsActivated == true)
            {
                this.CheckCharacterMana(character);

                character.DamageType = DamageType.Lightning;
                character.Damage += (int)(this.FirstLevelValue * AssassinSkillConstants.ShockWebDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AssassinSkillConstants.LightningSentryName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AssassinSkillConstants.ShockWebLightningSentryBonusValue * skill.Level);
                    }
                    if (skill.Name == AssassinSkillConstants.DeathSentryName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AssassinSkillConstants.ShockWebDeathSentryBonusValue * skill.Level);
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
                character.Damage -= (int)(this.FirstLevelValue * AssassinSkillConstants.ShockWebDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AssassinSkillConstants.LightningSentryName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AssassinSkillConstants.ShockWebLightningSentryBonusValue * skill.Level);
                    }
                    if (skill.Name == AssassinSkillConstants.DeathSentryName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AssassinSkillConstants.ShockWebDeathSentryBonusValue * skill.Level);
                    }
                }
            }
        }
    }
}
