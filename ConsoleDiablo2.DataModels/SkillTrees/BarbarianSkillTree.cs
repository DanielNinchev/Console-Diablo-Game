
using ConsoleDiablo2.Common.SkillConstants;
using ConsoleDiablo2.DataModels.Skills.BarbarianSkills;

namespace ConsoleDiablo2.DataModels.SkillTrees
{
    public class BarbarianSkillTree
    {
        public static Tree<string> InitializeBarbarianSkills()
        {
            Tree<string> barbarianSkills =
            new Tree<string>("BARBARIAN SKILLS:",
                new Tree<string>(BarbarianSkillConstants.ShoutName,
                    new Tree<string>(BarbarianSkillConstants.BattleOrdersName,
                        new Tree<string>(BarbarianSkillConstants.WarCryName))),
                new Tree<string>(BarbarianSkillConstants.StunName,
                    new Tree<string>(BarbarianSkillConstants.FerocityName,
                        new Tree<string>(BarbarianSkillConstants.BerzerkName),
                        new Tree<string>(BarbarianSkillConstants.WhirlwindName))),
                new Tree<string>(BarbarianSkillConstants.AxeMasteryName),
                new Tree<string>(BarbarianSkillConstants.FlailMasteryName),
                new Tree<string>(BarbarianSkillConstants.SwordMasteryName),
                new Tree<string>(BarbarianSkillConstants.IronSkinName,
                    new Tree<string>(BarbarianSkillConstants.NaturalResistanceName)));

            return barbarianSkills;
        }
    }
}
