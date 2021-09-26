using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Skills.Contracts;

using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.BarbarianSkills
{
    public class Stun : Skill, IEnemyAffectingSkill, IAffectableSkill
    {
        public Stun()
        {
            this.Name = BarbarianSkillConstants.StunName;
            this.RequiredSkill = BarbarianSkillConstants.StunRequiredSkill;
            this.RequiredLevel = BarbarianSkillConstants.StunRequiredLevel;
            this.ManaCost = BarbarianSkillConstants.StunManaCost;
            this.FirstLevelValue = BarbarianSkillConstants.StunFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.BarbarianSkillDescriptions);
        }

        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped == true && this.IsActivated == true)
            {
                this.CheckCharacterMana(character);

                character.DamageType = DamageType.Physical;
                character.Damage += (int)(this.FirstLevelValue * BarbarianSkillConstants.StunDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == BarbarianSkillConstants.FerocityName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * BarbarianSkillConstants.StunFerocityBonusValue * skill.Level);
                    }
                    if (skill.Name == BarbarianSkillConstants.BerzerkName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * BarbarianSkillConstants.ShoutWarCryBonusValue * skill.Level);
                    }
                    if (skill.Name == BarbarianSkillConstants.WhirlwindName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * BarbarianSkillConstants.StunWhirlwindBonusValue * skill.Level);
                    }
                }
            }
        }

        public void AffectEnemy(Being enemy)
        {
            if (this.IsDeveloped && this.IsActivated && enemy.IsAlive)
            {
                enemy.Damage -= BarbarianSkillConstants.StunEnemyDamageDecreaser * this.Level;
            }
        }

        public void UnaffectEnemy(Being enemy)
        {
            if (this.IsDeveloped && this.IsActivated && enemy.IsAlive)
            {
                enemy.Damage += BarbarianSkillConstants.StunEnemyDamageDecreaser * this.Level;
            }
        }

        public override void UnaffectCharacter(Character character)
        {
            if (this.IsActivated)
            {
                this.IsActivated = false;

                character.Damage -= (int)(this.FirstLevelValue * BarbarianSkillConstants.StunDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == BarbarianSkillConstants.FerocityName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * BarbarianSkillConstants.StunFerocityBonusValue * skill.Level);
                    }
                    if (skill.Name == BarbarianSkillConstants.BerzerkName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * BarbarianSkillConstants.ShoutWarCryBonusValue * skill.Level);
                    }
                }
            }
        }
    }
}
