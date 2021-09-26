using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Skills.Contracts;

using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AmazonSkills
{
    public class PowerStrike : Skill, IAffectableSkill
    {
        public PowerStrike()
        {
            this.Name = AmazonSkillConstants.PowerStrikeName;
            this.RequiredLevel = AmazonSkillConstants.PowerStrikeRequiredLevel;
            this.RequiredSkill = AmazonSkillConstants.PowerStrikeRequiredSkill;
            this.ManaCost = AmazonSkillConstants.PowerStrikeManaCost;
            this.FirstLevelValue = AmazonSkillConstants.PowerStrikeFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AmazonSkillDescriptions);
        }

        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped == true && this.IsActivated == true)
            {
                this.CheckCharacterMana(character);

                character.DamageType = DamageType.Physical;

                character.Damage = (int)(this.FirstLevelValue * AmazonSkillConstants.PowerStrikeDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AmazonSkillConstants.ChargedStrikeName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AmazonSkillConstants.PowerStrikeChargedStrikeBonusValue * skill.Level);
                    }
                    if (skill.Name == AmazonSkillConstants.ImpaleName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AmazonSkillConstants.PowerStrikeImpaleBonusValue * skill.Level);
                    }
                }
            }
        }

        public override void UnaffectCharacter(Character character)
        {
            if (this.IsActivated)
            {
                this.IsActivated = false;

                character.Damage -= (int)(this.FirstLevelValue * AmazonSkillConstants.PowerStrikeDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AmazonSkillConstants.ChargedStrikeName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AmazonSkillConstants.PowerStrikeChargedStrikeBonusValue * skill.Level);
                    }
                    if (skill.Name == AmazonSkillConstants.ImpaleName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AmazonSkillConstants.PowerStrikeImpaleBonusValue * skill.Level);
                    }
                }
            }
        }
    }
}
