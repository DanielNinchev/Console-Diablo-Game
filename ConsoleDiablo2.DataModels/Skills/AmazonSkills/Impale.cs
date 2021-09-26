using ConsoleDiablo2.Common;
using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Items.Weapons;

using System;
using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AmazonSkills
{
    public class Impale : Skill
    {
        public Impale()
        {
            this.Name = AmazonSkillConstants.ImpaleName;
            this.RequiredLevel = AmazonSkillConstants.ImpaleRequiredLevel;
            this.RequiredSkill = AmazonSkillConstants.ImpaleRequiredSkill;
            this.ManaCost = AmazonSkillConstants.ImpaleManaCost;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AmazonSkillDescriptions);
        }

        public override void AffectCharacter(Character character)
        {
            Weapon weapon = (Weapon)this.Character.Gear.Items.FirstOrDefault(i => i.GetType().IsSubclassOf(typeof(Weapon)));

            if (weapon != null)
            {
                if (this.IsDeveloped == true && this.IsActivated == true)
                {
                    this.CheckCharacterMana(character);

                    character.Damage *= AmazonSkillConstants.ImpaleDamageValue * this.Level;

                    weapon.Damage.Value /= AmazonSkillConstants.ImpaleWeaponDamageDivider;
                }
            }
            else
            {

                throw new ArgumentException(ExceptionMessages.YouNeedAWeaponToUseThisSkill);
            }
        }

        public override void UnaffectCharacter(Character character)
        {
            Weapon weapon = (Weapon)this.Character.Gear.Items.FirstOrDefault(i => i.GetType().IsSubclassOf(typeof(Weapon)));

            if (weapon != null)
            {
                if (this.IsDeveloped && this.IsActivated)
                {
                    this.IsActivated = false;

                    character.Damage /= AmazonSkillConstants.ImpaleDamageValue * this.Level;

                    weapon.Damage.Value *= AmazonSkillConstants.ImpaleWeaponDamageDivider;
                }
            }
        }
    }
}
