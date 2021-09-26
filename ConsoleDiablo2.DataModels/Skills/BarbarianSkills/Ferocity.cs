using ConsoleDiablo2.Common;
using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Skills.Contracts;
using System;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.BarbarianSkills
{
    public class Ferocity : Skill, IAffectableSkill
    {
        public Ferocity()
        {
            this.Name = BarbarianSkillConstants.FerocityName;
            this.RequiredLevel = BarbarianSkillConstants.FerocityRequiredLevel;
            this.RequiredSkill = BarbarianSkillConstants.FerocityRequiredSkill;
            this.ManaCost = BarbarianSkillConstants.FerocityManaCost;
            this.FirstLevelValue = BarbarianSkillConstants.FerocityFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.BarbarianSkillDescriptions);
        }

        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped == true && this.IsActivated == true)
            {
                this.CheckCharacterMana(character);

                character.Damage += (int)(BarbarianSkillConstants.FerocityDamageIncreaser * this.FirstLevelValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == BarbarianSkillConstants.StunName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * BarbarianSkillConstants.FerocityStunBonusValue * skill.Level);
                    }
                    if (skill.Name == BarbarianSkillConstants.BerzerkName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * BarbarianSkillConstants.FerocityBerzerkBonusValue * skill.Level);
                    }
                    if (skill.Name == BarbarianSkillConstants.WhirlwindName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * BarbarianSkillConstants.FerocityWhirlwindBonusValue * skill.Level);
                    }
                }
            }
        }

        public override void UnaffectCharacter(Character character)
        {
            if (this.IsActivated)
            {
                this.IsActivated = false;

                character.Damage -= (int)(BarbarianSkillConstants.FerocityDamageIncreaser * this.FirstLevelValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == BarbarianSkillConstants.StunName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * BarbarianSkillConstants.FerocityStunBonusValue * skill.Level);
                    }
                    if (skill.Name == BarbarianSkillConstants.BerzerkName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * BarbarianSkillConstants.FerocityBerzerkBonusValue * skill.Level);
                    }
                    if (skill.Name == BarbarianSkillConstants.WhirlwindName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * BarbarianSkillConstants.FerocityWhirlwindBonusValue * skill.Level);
                    }
                }
            }     
        }
    }
}
