using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Skills.Contracts;
using System;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AmazonSkills
{
    public class Seduction : Skill, IEnemyAffectingSkill, IAffectableSkill
    {
        private int unaffectedValue;
        public Seduction()
        {
            this.Name = AmazonSkillConstants.SeductionName;
            this.RequiredLevel = AmazonSkillConstants.SeductionRequiredLevel;
            this.RequiredSkill = AmazonSkillConstants.SeductionRequiredSkill;
            this.FirstLevelValue = AmazonSkillConstants.SeductionFirstLevelValue;
            this.unaffectedValue = this.FirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AmazonSkillDescriptions);
        }

        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped && this.IsActivated)
            {
                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AmazonSkillConstants.DodgeName)
                    {
                        this.FirstLevelValue += (int)(this.unaffectedValue * AmazonSkillConstants.SeductionDodgeBonusValue * skill.Level) - this.unaffectedValue;
                    }
                    if (skill.Name == AmazonSkillConstants.InnerSightName)
                    {
                        this.FirstLevelValue += (int)(this.unaffectedValue * AmazonSkillConstants.SeductionInnerSightBonusValue * skill.Level) - this.unaffectedValue;
                    }
                }
            }
        }

        public void AffectEnemy(Being enemy)
        {
            if (this.IsDeveloped && this.IsActivated && enemy.IsAlive)
            {
                enemy.Defense -= Math.Max((int)((this.FirstLevelValue / AmazonSkillConstants.SeductionDefenseValue) * this.Level), 0);
                enemy.Damage = 0;
            }
        }

        //TODO
        public void UnaffectEnemy(Being enemy)
        {

        }

        public override void UnaffectCharacter(Character character)
        {
            if (this.IsDeveloped && this.IsActivated)
            {
                this.IsActivated = false;

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AmazonSkillConstants.DodgeName)
                    {
                        this.FirstLevelValue -= (int)(this.unaffectedValue * AmazonSkillConstants.SeductionDodgeBonusValue * skill.Level) - this.unaffectedValue;
                    }
                    if (skill.Name == AmazonSkillConstants.InnerSightName)
                    {
                        this.FirstLevelValue -= (int)(this.unaffectedValue * AmazonSkillConstants.SeductionInnerSightBonusValue * skill.Level) - this.unaffectedValue;
                    }
                }
            }
        }
    }
}
