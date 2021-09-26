using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Skills.Contracts;

using System;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AssassinSkills
{
    public class HeadshotKick : Skill, IAffectableSkill
    {
        public HeadshotKick()
        {
            this.Name = AssassinSkillConstants.HeadshotKickName;
            this.RequiredLevel = AssassinSkillConstants.HeadshotKickRequiredLevel;
            this.RequiredSkill = AssassinSkillConstants.HeadshotKickRequiredSkill;
            this.ManaCost = AssassinSkillConstants.HeadshotKickManaCost;
            this.FirstLevelValue = AssassinSkillConstants.HeadshotKickFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AssassinSkillDescriptions);
        }

        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped == true && this.IsActivated == true)
            {
                this.CheckCharacterMana(character);

                character.DamageType = DamageType.Physical;

                character.Damage += (int)(this.FirstLevelValue * Math.Pow(AssassinSkillConstants.HeadshotKickDamageValue, this.Level));

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AssassinSkillConstants.DevastationName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * Math.Pow(AssassinSkillConstants.HeadshotKickDevastationBonusValue, skill.Level));
                    }
                    if (skill.Name == AssassinSkillConstants.AssassinationName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * Math.Pow(AssassinSkillConstants.HeadshotKickDevastationBonusValue, skill.Level));
                    }
                }
            }
        }

        public override void UnaffectCharacter(Character character)
        {
            if (this.IsActivated)
            {
                this.IsActivated = false;

                character.Damage -= (int)(this.FirstLevelValue * Math.Pow(AssassinSkillConstants.HeadshotKickDamageValue, this.Level));

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AssassinSkillConstants.DevastationName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * Math.Pow(AssassinSkillConstants.HeadshotKickDevastationBonusValue, skill.Level));
                    }
                    if (skill.Name == AssassinSkillConstants.AssassinationName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * Math.Pow(AssassinSkillConstants.HeadshotKickAssassinationBonusValue, skill.Level));
                    }
                }
            }
        }
    }
}
