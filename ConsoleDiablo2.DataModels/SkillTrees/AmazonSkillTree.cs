using ConsoleDiablo2.Common.SkillConstants;

namespace ConsoleDiablo2.DataModels.SkillTrees
{
    public class AmazonSkillTree
    {
        public static Tree<string> InitializeAmazonSkills()
        {
            Tree<string> amazonSkills =
            new Tree<string>("AMAZON SKILLS:",
                new Tree<string>(AmazonSkillConstants.PowerStrikeName,
                    new Tree<string>(AmazonSkillConstants.ChargedStrikeName),
                    new Tree<string>(AmazonSkillConstants.PoisonStrikeName,
                        new Tree<string>(AmazonSkillConstants.PlagueStrikeName))),
                new Tree<string>(AmazonSkillConstants.ImpaleName),
                new Tree<string>(AmazonSkillConstants.InnerSightName,
                    new Tree<string>(AmazonSkillConstants.DodgeName,
                        new Tree<string>(AmazonSkillConstants.SeductionName))),
                new Tree<string>(AmazonSkillConstants.SpearMasteryName,
                    new Tree<string>(AmazonSkillConstants.CriticalStrikeName)),
                new Tree<string>(AmazonSkillConstants.PassiveMasteryName),
                new Tree<string>(AmazonSkillConstants.ValkyrismName));

            return amazonSkills;
        }
    }
}
