using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Items.Weapons;

using System.Linq;

namespace ConsoleDiablo2.DataModels.Skills.AssassinSkills
{
    public class WeaponBlock : Skill
    {
        public WeaponBlock()
        {
            this.Name = AssassinSkillConstants.WeaponBlockName;
            this.RequiredLevel = AssassinSkillConstants.WeaponBlockRequiredLevel;
            this.RequiredSkill = AssassinSkillConstants.WeaponBlockRequiredSkill;
            this.Description = base.InitializeSkillDescription(SkillDescriptions.AssassinSkillDescriptions);
            this.IsPassive = true;
        }

        public override void AffectCharacter(Character character)
        {
            int weaponCount = 0;

            foreach (var item in character.Gear.Items.Where(i => i.GetType().IsSubclassOf(typeof(Weapon))))
            {
                weaponCount++;
            }
            if (weaponCount > 0)
            {
                character.ChanceToBlock += (AssassinSkillConstants.WeaponBlockValue * weaponCount);
            }
        }

        public override void UnaffectCharacter(Character character)
        {

        }
    }
}
