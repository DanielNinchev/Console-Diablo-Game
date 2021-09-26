using System.Collections.Generic;

namespace ConsoleDiablo2.Common
{
    public static class BonusConstants
    {
        public const string Percentage = "%";
        public const string Plus = "+";
        public const string To = " to ";

        //Bonus max values
        public const int MaxChanceOfCriticalHit = 100;
        public const int MaxChanceToBlock = 100;

        //Bonus descriptions
        public const string DamageBonusDesc = "Damage: + ";
        public const string DefenseBonusDesc = "Defense: + ";

        public const string AccuracyBonusDesc = "Accuracy: ";

        public const string LifeBonusDesc = "Life: + ";
        public const string ManaBonusDesc = "Mana: + ";
        public const string LifeTapBonusDesc = " life stolen per hit";
        public const string ManaTapBonusDesc = " mana stolen per hit";

        public const string FireResBonusDesc = "Fire Resistance: + ";
        public const string ColdResBonusDesc = "Cold Resistance: + ";
        public const string LightningResBonusDesc = "Lightning Resistance: + ";
        public const string PoisonResBonusDesc = "Poison Resistance: + ";
        public const string AllResBonusDesc = "All Resistances: + ";

        public static List<string> ResBonusDescs = new List<string>
        {
            FireResBonusDesc,
            ColdResBonusDesc,
            LightningResBonusDesc,
            AllResBonusDesc
        };

        public const string FireSkillDamageDesc = "Fire Skill Damage: + ";
        public const string LightningSkillDamageDesc = "Lightning Skill Damage: + ";
        public const string ColdSkillDamageDesc = "Cold Skill Damage: + ";
        public const string PoisonSkillDamageDesc = "Poison Skill Damage: + ";
        public const string AllSkillsDesc = " to all skills";

        public const string ChanceToBlockBonusDesc = "Chance to Block: + ";
        public const string ChanceOfCriticalHit = "Chance of Critical Hit: + ";
        public const string IgnoreTargetsDefense = "Ignore target's defense";

        public const string DamageToMonsterTypeDesc = " % damage to ";
        public const string SmiteDamageDesc = "Smite Damage: + ";

        public static List<string> AxeSkillBonuses = new List<string>
        {
            "Stun",
            "Ferocity",
            "Berzerk",
            "Whirlwind",
            "Axe Mastery",
        };

        public static List<string> DaggerSkillBonuses = new List<string>
        {
            "Poison Dagger",
            "Assassination",
        };

        public static List<string> FlailSkillBonuses = new List<string>
        {
            "Stun",
            "Ferocity",
            "Berzerk",
            "Whirlwind",
            "Flail Mastery",
        };

        public static List<string> ScepterSkillBonuses = new List<string>
        {
            "Stun",
            "Ferocity",
            "Berzerk",
            "Whirlwind",
            "Flail Mastery",
        };

        public static List<string> SpearSkillBonuses = new List<string>
        {
            "Stun",
            "Ferocity",
            "Berzerk",
            "Whirlwind",
            "Flail Mastery",
        };

        public static List<string> StaffSkillBonuses = new List<string>
        {
            "Stun",
            "Ferocity",
            "Berzerk",
            "Whirlwind",
            "Flail Mastery",
        };

        public static List<string> SwordSkillBonuses = new List<string>
        {
            "Stun",
            "Ferocity",
            "Berzerk",
            "Whirlwind",
            "Flail Mastery",
        };

        public static List<string> WandSkillBonuses = new List<string>
        {
            "Stun",
            "Ferocity",
            "Berzerk",
            "Whirlwind",
            "Flail Mastery",
        };
    }
}
