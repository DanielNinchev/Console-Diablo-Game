using ConsoleDiablo2.Common;
using ConsoleDiablo2.DataModels.SkillTrees;

namespace ConsoleDiablo2.DataModels.Characters
{
    public class Amazon : Character
    {
        public Amazon(string name, bool isDeleted)
            : base (name, isDeleted,
                  damage: CharacterConstants.AmazonDamage,
                  baseLife: CharacterConstants.AmazonBaseLife,
                  baseMana: CharacterConstants.AmazonBaseMana)
        {
            this.SkillTree = AmazonSkillTree.InitializeAmazonSkills();
        }
    }
}
