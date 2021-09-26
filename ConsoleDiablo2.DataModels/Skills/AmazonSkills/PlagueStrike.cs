using ConsoleDiablo2.Common;
using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Skills.Contracts;

using System;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AmazonSkills
{
    public class PlagueStrike : Skill, IAura, IEnemyAffectingSkill, IAffectableSkill
    {
        public PlagueStrike()
        {
            this.Name = AmazonSkillConstants.PoisonStrikeName;
            this.RequiredLevel = AmazonSkillConstants.PoisonStrikeRequiredLevel;
            this.RequiredSkill = AmazonSkillConstants.PoisonStrikeRequiredSkill;
            this.ManaCost = AmazonSkillConstants.PoisonStrikeManaCost;
            this.RoundDuration = AmazonSkillConstants.PlagueStrikeRoundsPerLevel;
            this.FirstLevelValue = AmazonSkillConstants.PlagueStrikeFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AmazonSkillDescriptions);
        }

        public double RoundDuration { get; set; }
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
                        character.Damage += (int)(this.FirstLevelValue * AmazonSkillConstants.PlagueStrikePowerStrikeBonusValue * skill.Level);
                    }
                    if (skill.Name == AmazonSkillConstants.PoisonStrikeName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AmazonSkillConstants.PlagueStrikePoisonStrikeBonusValue * skill.Level);
                    }
                }
            }
        }

        public void AffectEnemy(Being enemy)
        {
            enemy.IsPoisoned = true;

            enemy.BeingPoisoned(enemy.Life / 10);
        }

        public void DeactivateSkill(params object[] args)
        {
            int round = (int)args[0];
            Character character = (Character)args[1];
            Being enemy = (Being)args[2];

            if (round > this.RoundDuration)
            {
                this.UnaffectCharacter(character);
                this.UnaffectEnemy(enemy);
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
                        character.Damage -= (int)(this.FirstLevelValue * AmazonSkillConstants.PlagueStrikePowerStrikeBonusValue * skill.Level);
                    }
                    if (skill.Name == AmazonSkillConstants.PoisonStrikeName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AmazonSkillConstants.PlagueStrikePoisonStrikeBonusValue * skill.Level);
                    }
                }
            }
        }

        public void UnaffectEnemy(Being enemy)
        {
            enemy.IsPoisoned = false;
        }
    }
}
