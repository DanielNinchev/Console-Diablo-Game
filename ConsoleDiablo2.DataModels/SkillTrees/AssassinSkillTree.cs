using ConsoleDiablo2.Common.SkillConstants;

namespace ConsoleDiablo2.DataModels.SkillTrees
{
    public class AssassinSkillTree
    {
        public static Tree<string> InitializeAssassinSkills()
        {
            Tree<string> assassinSkills =
            new Tree<string>("ASSASSIN SKILLS:",
                new Tree<string>(AssassinSkillConstants.WeaponBlockName),
                new Tree<string>(AssassinSkillConstants.MartialArtsName,
                    new Tree<string>(AssassinSkillConstants.VenomName)),
                new Tree<string>(AssassinSkillConstants.DaggerMasteryName),
                new Tree<string>(AssassinSkillConstants.ShockWebName,
                    new Tree<string>(AssassinSkillConstants.LightningSentryName,
                        new Tree<string>(AssassinSkillConstants.DeathSentryName)),
                    new Tree<string>(AssassinSkillConstants.FireDaggerName,
                        new Tree<string>(AssassinSkillConstants.ExplosiveDaggerName))),
                new Tree<string>(AssassinSkillConstants.HeadshotKickName,
                    new Tree<string>(AssassinSkillConstants.DevastationName,
                        new Tree<string>(AssassinSkillConstants.AssassinationName))));

            return assassinSkills;
        }
    }
}