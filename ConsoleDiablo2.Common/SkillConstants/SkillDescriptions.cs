using System.Collections.Generic;

namespace ConsoleDiablo2.Common.SkillConstants
{
    public class SkillDescriptions
    {
        public const string NoRequiredSkill = "None";

        public static List<List<string>> AmazonSkillDescriptions = new List<List<string>>()
            {
                AmazonSkillConstants.powerStrikeDesc,
                AmazonSkillConstants.chargedStrikeDesc,
                AmazonSkillConstants.ImpaleDesc,
                AmazonSkillConstants.poisonStrikeDesc,
                AmazonSkillConstants.PlagueStrikeDesc,
                AmazonSkillConstants.innerSightDesc,
                AmazonSkillConstants.dodgeDesc,
                AmazonSkillConstants.seductionDesc,
                AmazonSkillConstants.spearMasteryDesc,
                AmazonSkillConstants.criticalStrikeDesc,
                AmazonSkillConstants.passiveMasteryDesc,
                AmazonSkillConstants.valkyrismDesc
            };

        public static List<List<string>> AssassinSkillDescriptions = new List<List<string>>()
            {
                AssassinSkillConstants.weaponBlockDesc,
                AssassinSkillConstants.martialArtsDesc,
                AssassinSkillConstants.venomDesc,
                AssassinSkillConstants.daggerMasteryDesc,
                AssassinSkillConstants.shockWebDesc,
                AssassinSkillConstants.lightningSentryDesc,
                AssassinSkillConstants.deathSentryDesc,
                AssassinSkillConstants.fireDaggerDesc,
                AssassinSkillConstants.explosiveDaggerDesc,
                AssassinSkillConstants.headshotKickDesc,
                AssassinSkillConstants.devastationDesc,
                AssassinSkillConstants.assassinationDesc
            };

        public static List<List<string>> BarbarianSkillDescriptions = new List<List<string>>()
            {
                BarbarianSkillConstants.axeMasteryDesc,
                BarbarianSkillConstants.flailMasteryDesc,
                BarbarianSkillConstants.swordMasteryDesc,
                BarbarianSkillConstants.ironSkinDesc,
                BarbarianSkillConstants.naturalResistanceDesc,
                BarbarianSkillConstants.shoutDesc,
                BarbarianSkillConstants.battleOrdersDesc,
                BarbarianSkillConstants.warCryDesc,
                BarbarianSkillConstants.stunDesc,
                BarbarianSkillConstants.ferocityDesc,
                BarbarianSkillConstants.berzerkDesc,
                BarbarianSkillConstants.whirlwindDesc
            };
    }
}
