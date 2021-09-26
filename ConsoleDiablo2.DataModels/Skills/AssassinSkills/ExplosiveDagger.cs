using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Enums;
using ConsoleDiablo2.DataModels.Items.Weapons;
using ConsoleDiablo2.DataModels.Skills.Contracts;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AssassinSkills
{
    public class ExplosiveDagger : Skill, IEnemyAffectingSkill, IAffectableSkill
    {
        public ExplosiveDagger()
        {
            this.Name = AssassinSkillConstants.ExplosiveDaggerName;
            this.RequiredLevel = AssassinSkillConstants.ExplosiveDaggerRequiredLevel;
            this.RequiredSkill = AssassinSkillConstants.ExplosiveDaggerRequiredSkill;
            this.ManaCost = AssassinSkillConstants.ExplosiveDaggerManaCost;
            this.FirstLevelValue = AssassinSkillConstants.ExplosiveDaggerFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AssassinSkillDescriptions);
        }

        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped == true && this.IsActivated == true && character.Gear.Items.Any(i => i.GetType() == typeof(Dagger)))
            {
                this.CheckCharacterMana(character);

                character.DamageType = DamageType.Fire;
                character.Damage += (int)(this.FirstLevelValue * AssassinSkillConstants.ExplosiveDaggerDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AssassinSkillConstants.ShockWebName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AssassinSkillConstants.ExplosiveDaggerShockWebBonusValue * skill.Level);
                    }
                    if (skill.Name == AssassinSkillConstants.FireDaggerName)
                    {
                        character.Damage += (int)(this.FirstLevelValue * AssassinSkillConstants.ExplosiveDaggerFireDaggerBonusValue * skill.Level);
                    }
                }
            }
        }

        public void AffectEnemy(Being enemy)
        {
            if (this.IsDeveloped == true && this.IsActivated == true && enemy.IsAlive == true)
            {
                enemy.FireResistance -= AssassinSkillConstants.ExplosiveDaggerFireResDrainageValue;
            }
        }

        public void UnaffectEnemy(Being enemy)
        {
            if (this.IsDeveloped == true && this.IsActivated == false && enemy.IsAlive == true)
            {
                enemy.FireResistance += AssassinSkillConstants.ExplosiveDaggerFireResDrainageValue;
            }
        }

        public override void UnaffectCharacter(Character character)
        {
            if (this.IsActivated)
            {
                this.IsActivated = false;

                character.DamageType = DamageType.Physical;
                character.Damage -= (int)(this.FirstLevelValue * AssassinSkillConstants.ExplosiveDaggerDamageValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == AssassinSkillConstants.ShockWebName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AssassinSkillConstants.ExplosiveDaggerShockWebBonusValue * skill.Level);
                    }
                    if (skill.Name == AssassinSkillConstants.FireDaggerName)
                    {
                        character.Damage -= (int)(this.FirstLevelValue * AssassinSkillConstants.ExplosiveDaggerFireDaggerBonusValue * skill.Level);
                    }
                }
            }
        }
    }
}
