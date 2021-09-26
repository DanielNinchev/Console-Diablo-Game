using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Skills.Contracts;

using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.BarbarianSkills
{
    public class Shout : Skill, IAura, IAffectableSkill
    {
        public Shout()
        {
            this.Name = BarbarianSkillConstants.ShoutName;
            this.ManaCost = BarbarianSkillConstants.ShoutManaCost;
            this.RequiredLevel = BarbarianSkillConstants.ShoutRequiredLevel;
            this.RequiredSkill = BarbarianSkillConstants.ShoutRequiredSkill;
            this.RoundDuration = BarbarianSkillConstants.ShoutRoundDuration * this.Level;
            this.FirstLevelValue = BarbarianSkillConstants.ShoutFirstLevelValue;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.BarbarianSkillDescriptions);
        }

        public double RoundDuration { get; set; }
        public int FirstLevelValue { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped == true && this.IsActivated == true)
            {
                this.CheckCharacterMana(character);

                character.Defense += (int)(this.FirstLevelValue * BarbarianSkillConstants.ShoutDefenseValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == BarbarianSkillConstants.BattleOrdersName)
                    {
                        character.Defense += (int)(this.FirstLevelValue * BarbarianSkillConstants.ShoutBattleOrdersBonusValue * skill.Level);
                    }
                    if (skill.Name == BarbarianSkillConstants.WarCryName)
                    {
                        character.Defense += (int)(this.FirstLevelValue * BarbarianSkillConstants.ShoutWarCryBonusValue * skill.Level);
                    }
                }
            }
        }

        public void DeactivateSkill(params object[] args)
        {
            int round = (int)args[0];
            Character character = (Character)args[1];

            int endDurationRound = (int)(round + this.RoundDuration);

            if (round >= endDurationRound)
            {
                this.UnaffectCharacter(character);
            }
        }

        public override void UnaffectCharacter(Character character)
        {
            if (this.IsActivated)
            {
                this.IsActivated = false;
                character.Defense -= (int)(this.FirstLevelValue * BarbarianSkillConstants.ShoutDefenseValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == BarbarianSkillConstants.BattleOrdersName)
                    {
                        character.Defense -= (int)(this.FirstLevelValue * BarbarianSkillConstants.ShoutBattleOrdersBonusValue * skill.Level);
                    }
                    if (skill.Name == BarbarianSkillConstants.WarCryName)
                    {
                        character.Defense -= (int)(this.FirstLevelValue * BarbarianSkillConstants.ShoutWarCryBonusValue * skill.Level);
                    }
                }
            }
        }
    }
}
