using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Skills.Contracts;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AmazonSkills
{
    public class PoisonStrike : Skill, IAffectableSkill
    {
        public PoisonStrike()
        {
            this.Name = AmazonSkillConstants.PoisonStrikeName;
            this.RequiredLevel = AmazonSkillConstants.PoisonStrikeRequiredLevel;
            this.RequiredSkill = AmazonSkillConstants.PoisonStrikeRequiredSkill;
            this.ManaCost = AmazonSkillConstants.PoisonStrikeManaCost;
            this.FirstLevelValue = AmazonSkillConstants.PoisonStrikeFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AmazonSkillDescriptions);
        }

        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped == true && this.IsActivated == true)
            {
                this.CheckCharacterMana(character);

                character.DamageType = DamageType.Poison;
                character.Damage += (int)(this.FirstLevelValue * AmazonSkillConstants.PoisonStrikeDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AmazonSkillConstants.PowerStrikeName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AmazonSkillConstants.PoisonStrikePowerStrikeBonusValue * skill.Level);
                    }
                    if (skill.Name == AmazonSkillConstants.PlagueStrikeName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AmazonSkillConstants.PoisonStrikePlagueStrikeBonusValue * skill.Level);
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
                character.Damage -= (int)(this.FirstLevelValue * AmazonSkillConstants.PoisonStrikeDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AmazonSkillConstants.PowerStrikeName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AmazonSkillConstants.PoisonStrikePowerStrikeBonusValue * skill.Level);
                    }
                    if (skill.Name == AmazonSkillConstants.PlagueStrikeName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AmazonSkillConstants.PoisonStrikePlagueStrikeBonusValue * skill.Level);
                    }
                }
            }
        }
    }
}
