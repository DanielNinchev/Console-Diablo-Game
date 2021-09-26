using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Skills.Contracts;
using System;

namespace ConsoleDiablo2.DataModels.Skills.AssassinSkills
{
    public class Assassination : Skill, IEnemyAffectingSkill
    {
        public Assassination()
        {
            this.Name = AssassinSkillConstants.AssassinationName;
            this.RequiredLevel = AssassinSkillConstants.AssassinationRequiredLevel;
            this.RequiredSkill = AssassinSkillConstants.AssassinationRequiredSkill;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AssassinSkillDescriptions);
        }

        public override void AffectCharacter(Character character)
        {
            this.ManaCost = character.BaseMana / 2;

            this.CheckCharacterMana(character);
        }

        public void AffectEnemy(Being enemy)
        {
            if (this.IsDeveloped == true && this.IsActivated == true && enemy.IsAlive == true)
            {
                Random random = new Random();
                int successConstant = random.Next(1, 100);

                if (successConstant <= AssassinSkillConstants.AssassinationValue * this.Level)
                {
                    enemy.Life = 0;
                    enemy.IsAlive = false;
                }
            }
        }

        public override void UnaffectCharacter(Character character)
        {
            if (this.IsActivated)
            {
                this.IsActivated = false;
            }
        }

        public void UnaffectEnemy(Being enemy)
        {
        }
    }
}
