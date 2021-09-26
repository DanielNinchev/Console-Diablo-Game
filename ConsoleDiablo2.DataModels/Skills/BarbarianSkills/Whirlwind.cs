using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Skills.Contracts;

using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.BarbarianSkills
{
    public class Whirlwind : Skill
    {
        private double unaffectedDamage;

        public Whirlwind()
        {
            this.Name = BarbarianSkillConstants.WhirlwindName;
            this.RequiredLevel = BarbarianSkillConstants.WhirlwindRequiredLevel;
            this.RequiredSkill = BarbarianSkillConstants.WhirlwindRequiredSkill;
            this.ManaCost = BarbarianSkillConstants.WhirlwindManaCost;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.BarbarianSkillDescriptions);
        }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped == true && this.IsActivated == true)
            {
                this.CheckCharacterMana(character);

                this.unaffectedDamage = character.Damage;

                character.Damage += BarbarianSkillConstants.WhirlwindHitsValue * this.Level * this.unaffectedDamage;

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == BarbarianSkillConstants.FerocityName)
                    {
                        character.Damage += (int)(this.unaffectedDamage * BarbarianSkillConstants.WhirlwindFerocityBonusValue * skill.Level) - this.unaffectedDamage;
                    }
                    if (skill.Name == BarbarianSkillConstants.StunName)
                    {
                        character.Damage += (int)(this.unaffectedDamage * BarbarianSkillConstants.WhirlwindStunBonusValue * skill.Level) - this.unaffectedDamage;
                    }
                }
            }
        }

        public override void UnaffectCharacter(Character character)
        {
            if (this.IsActivated)
            {
                this.IsActivated = false;

                character.Damage -= BarbarianSkillConstants.WhirlwindHitsValue * this.Level * this.unaffectedDamage;

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == BarbarianSkillConstants.FerocityName)
                    {
                        character.Damage -= (int)(this.unaffectedDamage * BarbarianSkillConstants.WhirlwindFerocityBonusValue * skill.Level) - this.unaffectedDamage;
                    }
                    if (skill.Name == BarbarianSkillConstants.StunName)
                    {
                        character.Damage -= (int)(this.unaffectedDamage * BarbarianSkillConstants.WhirlwindStunBonusValue * skill.Level) - this.unaffectedDamage;
                    }
                }
            }
        }
    }
}
