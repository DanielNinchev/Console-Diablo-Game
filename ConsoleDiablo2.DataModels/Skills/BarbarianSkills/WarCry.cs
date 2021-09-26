using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Skills.Contracts;

using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.BarbarianSkills
{
    public class WarCry : Skill, IAura
    {
        public WarCry()
        {
            this.Name = BarbarianSkillConstants.WarCryName;
            this.RequiredLevel = BarbarianSkillConstants.WarCryRequiredLevel;
            this.RequiredSkill = BarbarianSkillConstants.WarCryRequiredSkill;
            this.ManaCost = BarbarianSkillConstants.WarCryManaCost;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.BarbarianSkillDescriptions);
        }

        public double RoundDuration { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped == true && this.IsActivated == true)
            {
                this.CheckCharacterMana(character);

                foreach (var skill in character.Skills.Where(sk => sk.IsDeveloped))
                {
                    int level = BarbarianSkillConstants.WarCrySkillLevelValue * this.Level;
                    skill.Level += (byte)level;

                    if (skill.IsPassive)
                    {
                        skill.AffectCharacter(character);
                    }
                }

                this.RoundDuration = BarbarianSkillConstants.WarCryRoundDuration * this.Level;
            }
        }

        public void DeactivateSkill(params object[] args)
        {
            int round = (int)args[0];
            Character character = (Character)args[1];

            if (round > this.RoundDuration)
            {
                this.UnaffectCharacter(character);
            }
        }

        public override void UnaffectCharacter(Character character)
        {
            if (this.IsActivated)
            {
                this.IsActivated = false;

                foreach (var skill in character.Skills.Where(sk => sk.IsDeveloped))
                {
                    int level = BarbarianSkillConstants.WarCrySkillLevelValue * this.Level;
                    skill.Level -= (byte)level;
                }
            }
        }
    }
}
