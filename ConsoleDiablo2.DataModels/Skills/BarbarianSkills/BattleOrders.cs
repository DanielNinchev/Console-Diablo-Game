using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Skills.Contracts;

using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.BarbarianSkills
{
    public class BattleOrders : Skill, IAura
    {
        public BattleOrders()
        {
            this.Name = BarbarianSkillConstants.BattleOrdersName;
            this.RequiredLevel = BarbarianSkillConstants.BattleOrdersRequiredLevel;
            this.RequiredSkill = BarbarianSkillConstants.BattleOrdersRequiredSkill;
            this.ManaCost = BarbarianSkillConstants.BattleOrdersManaCost;
            this.RoundDuration = BarbarianSkillConstants.BattleOrdersRoundDuration * this.Level;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.BarbarianSkillDescriptions);
        }

        public double RoundDuration { get; set; }

        public override void AffectCharacter(Character character)
        {
            if (this.IsDeveloped == true && this.IsActivated == true)
            {
                this.CheckCharacterMana(character);

                character.BaseLife = (int)(character.BaseLife * BarbarianSkillConstants.BattleOrdersLifeValue * this.Level);
                character.BaseMana = (int)(character.BaseMana * BarbarianSkillConstants.BattleOrdersManaValue * this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == BarbarianSkillConstants.ShoutName)
                    {
                        character.BaseLife = (int)(character.BaseLife * BarbarianSkillConstants.BattleOrdersShoutBonusValue * skill.Level);
                        character.BaseMana = (int)(character.BaseMana * BarbarianSkillConstants.BattleOrdersShoutBonusValue * skill.Level);
                    }
                    if (skill.Name == BarbarianSkillConstants.WarCryName)
                    {
                        character.BaseLife = (int)(character.BaseLife * BarbarianSkillConstants.BattleOrdersWarCryBonusValue * skill.Level);
                        character.BaseMana = (int)(character.BaseMana * BarbarianSkillConstants.BattleOrdersWarCryBonusValue * skill.Level);
                    }
                }

                character.Life = character.BaseLife;
                character.Mana = character.BaseMana;
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
                character.BaseLife = (int)(character.BaseLife / BarbarianSkillConstants.BattleOrdersLifeValue / this.Level);         
                character.BaseMana = (int)(character.BaseMana / BarbarianSkillConstants.BattleOrdersManaValue / this.Level);

                foreach (var skill in character.Skills.Where(s => s.IsDeveloped))
                {
                    if (skill.Name == BarbarianSkillConstants.ShoutName)
                    {
                        character.BaseLife = (int)(character.BaseLife / BarbarianSkillConstants.BattleOrdersShoutBonusValue / skill.Level);
                        character.BaseMana = (int)(character.BaseMana / BarbarianSkillConstants.BattleOrdersShoutBonusValue / skill.Level);
                    }
                    if (skill.Name == BarbarianSkillConstants.WarCryName)
                    {
                        character.BaseLife = (int)(character.BaseLife / BarbarianSkillConstants.BattleOrdersWarCryBonusValue / skill.Level);
                        character.BaseMana = (int)(character.BaseMana / BarbarianSkillConstants.BattleOrdersWarCryBonusValue / skill.Level);
                    }
                }

                character.Life = character.BaseLife;
                character.Mana = character.BaseMana;
            }
        }
    }
}
