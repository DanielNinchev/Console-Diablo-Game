using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Skills.Contracts;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AmazonSkills
{
    public class ChargedStrike : Skill, IAffectableSkill
    {
        public ChargedStrike()
        {
            this.Name = AmazonSkillConstants.ChargedStrikeName;
            this.RequiredLevel = AmazonSkillConstants.ChargedStrikeRequiredLevel;
            this.RequiredSkill = AmazonSkillConstants.ChargedStrikeRequiredSkill;
            this.ManaCost = AmazonSkillConstants.ChargedStrikeManaCost;
            this.FirstLevelValue = AmazonSkillConstants.ChargedStrikeFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AmazonSkillDescriptions);
        }

        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped && this.IsActivated)
            {
                this.CheckCharacterMana(character);

                character.DamageType = DamageType.Lightning;
                character.Damage += (int)(this.FirstLevelValue * AmazonSkillConstants.ChargedStrikeDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AmazonSkillConstants.PowerStrikeName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AmazonSkillConstants.ChargedStrikePowerStrikeBonusValue * skill.Level);
                    }
                    if (skill.Name == AmazonSkillConstants.ImpaleName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AmazonSkillConstants.ChargedStrikeImpaleBonusValue * skill.Level);
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
                character.Damage -= (int)(this.FirstLevelValue * AmazonSkillConstants.ChargedStrikeDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AmazonSkillConstants.PowerStrikeName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AmazonSkillConstants.ChargedStrikePowerStrikeBonusValue * skill.Level);
                    }
                    if (skill.Name == AmazonSkillConstants.ImpaleName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AmazonSkillConstants.ChargedStrikeImpaleBonusValue * skill.Level);
                    }
                }
            }
        }
    }
}
