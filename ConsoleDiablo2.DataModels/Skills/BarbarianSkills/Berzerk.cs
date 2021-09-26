using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Skills.Contracts;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.BarbarianSkills
{
    public class Berzerk : Skill, IAffectableSkill
    {
        public Berzerk()
        {
            this.Name = BarbarianSkillConstants.BerzerkName;
            this.RequiredLevel = BarbarianSkillConstants.BerzerkRequiredLevel;
            this.RequiredSkill = BarbarianSkillConstants.BerzerkRequiredSkill;
            this.ManaCost = BarbarianSkillConstants.BerzerkManaCost;
            this.FirstLevelValue = BarbarianSkillConstants.BerzerkFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.BarbarianSkillDescriptions);
        }

        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped == true && this.IsActivated == true)
            {
                this.CheckCharacterMana(character);

                character.Damage += (int)(this.FirstLevelValue * BarbarianSkillConstants.BerzerkDamageIncreaser * this.Level);
                character.Defense = (int)(character.Defense / BarbarianSkillConstants.BerzerkDefenseDivider / this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == BarbarianSkillConstants.FerocityName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * BarbarianSkillConstants.BerzerkFerocityBonusValue * skill.Level);
                    }
                    if (skill.Name == BarbarianSkillConstants.StunName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * BarbarianSkillConstants.BerzerkStunBonusValue * skill.Level);
                    }
                }
            }
        }

        public override void UnaffectCharacter(Character character)
        {
            if (this.IsActivated)
            {
                this.IsActivated = false;
                character.Damage -= (int)(this.FirstLevelValue * BarbarianSkillConstants.BerzerkDamageIncreaser * this.Level);
                character.Defense = (int)(character.Defense * BarbarianSkillConstants.BerzerkDefenseDivider * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == BarbarianSkillConstants.FerocityName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * BarbarianSkillConstants.BerzerkFerocityBonusValue * skill.Level);
                    }
                    if (skill.Name == BarbarianSkillConstants.StunName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * BarbarianSkillConstants.BerzerkStunBonusValue * skill.Level);
                    }
                }
            }
        }
    }
}
