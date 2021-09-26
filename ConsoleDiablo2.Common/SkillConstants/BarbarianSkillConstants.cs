using System;
using System.Collections.Generic;

namespace ConsoleDiablo2.Common.SkillConstants
{
    public static class BarbarianSkillConstants
    {
        //Axe Mastery
        public const string AxeMasteryName = "Axe Mastery";
        public const string AxeMasteryDescription = "[Passive] Develops your axe-fighting skills.";

        public const string AxeMasteryRequiredSkill = "None";
        public const string AxeMasteryRequiredSkillDesc = "Required Skill: ";

        public const string AxeMasteryRequiredLevelDesc = "Required Level: ";
        public const int AxeMasteryRequiredLevel = 1;

        public const string AxeMasteryDamageValueDesc = "Physical damage per each skill level when fighting with an axe: +25% of your axe's damage";
        public const double AxeMasteryDamageValue = 0.25;

        public static List<string> axeMasteryDesc = new List<string>
        {
            AxeMasteryName,
            AxeMasteryDescription,
            AxeMasteryDamageValueDesc,
            String.Concat(AxeMasteryRequiredSkillDesc, AxeMasteryRequiredSkill),
            String.Concat(AxeMasteryRequiredLevelDesc, AxeMasteryRequiredLevel.ToString()),

        };

        //Flail Mastery
        public const string FlailMasteryName = "Flail Mastery";
        public const string FlailMasteryDescription = "[Passive] Develops your flail-fighting skills.";

        public const string FlailMasteryRequiredSkill = "None";
        public const string FlailMasteryRequiredSkillDesc = "Required Skill: ";

        public const string FlailMasteryRequiredLevelDesc = "Required Level: ";
        public const int FlailMasteryRequiredLevel = 1;

        public const string FlailMasteryDamageValueDesc = "Physical damage per each skill level when fighting with a flail: +30% of your flail's damage";
        public const double FlailMasteryDamageValue = 0.3;

        public static List<string> flailMasteryDesc = new List<string>
        {
            FlailMasteryName,
            FlailMasteryDescription,
            FlailMasteryDamageValueDesc,
            String.Concat(FlailMasteryRequiredSkillDesc, FlailMasteryRequiredSkill),
            String.Concat(FlailMasteryRequiredLevelDesc, FlailMasteryRequiredLevel.ToString()),
        };

        //Sword Mastery
        public const string SwordMasteryName = "Sword Mastery";
        public const string SwordMasteryDescription = "[Passive] Develops your sword-fighting skills.";

        public const string SwordMasteryRequiredSkill = "None";
        public const string SwordMasteryRequiredSkillDesc = "Required Skill: ";

        public const string SwordMasteryRequiredLevelDesc = "Required Level: ";
        public const int SwordMasteryRequiredLevel = 1;

        public const string SwordMasteryDamageValueDesc = "Physical damage per each skill level when fighting with a sword: +30% of your sword's damage";
        public const double SwordMasteryDamageValue = 0.3;

        public static List<string> swordMasteryDesc = new List<string>
        {
            SwordMasteryName,
            SwordMasteryDescription,
            SwordMasteryDamageValueDesc,
            String.Concat(SwordMasteryRequiredSkillDesc, SwordMasteryRequiredSkill),
            String.Concat(SwordMasteryRequiredLevelDesc, SwordMasteryRequiredLevel.ToString()),
        };

        //Iron Skin
        public const string IronSkinName = "Iron Skin";
        public const string IronSkinDescription = "[Passive] Increases your defense.";

        public const string IronSkinFirstLevelValueDesc = "First level: Defense +300";
        public const int IronSkinFirstLevelValue = 300;

        public const string IronSkinRequiredSkill = "None";
        public const string IronSkinRequiredSkillDesc = "Required Skill: ";

        public const string IronSkinRequiredLevelDesc = "Required Level: ";
        public const int IronSkinRequiredLevel = 6;

        public const string IronSkinDefenseValueDesc = "Defense pear each skill level: +20% ";
        public const double IronSkinDefenseValue = 0.2;

        public static List<string> ironSkinDesc = new List<string>
        {
            IronSkinName,
            IronSkinDescription,
            IronSkinFirstLevelValueDesc,
            IronSkinDefenseValueDesc,
            String.Concat(IronSkinRequiredSkillDesc, IronSkinRequiredSkill),
            String.Concat(IronSkinRequiredLevelDesc, IronSkinRequiredLevel.ToString()),
        };

        //Natural Resistance
        public const string NaturalResistanceName = "Natural Resistance";
        public const string NaturalResistanceDescription = "[Passive] Increases all your resistances (fire, lightning, cold, poison).";

        public const string NaturalResistanceRequiredLevelDesc = "Required Level: ";
        public const int NaturalResistanceRequiredLevel = 10;

        public const string NaturalResistanceValueDesc = "All resistances per each skill level: + 5%";
        public const int NaturalResistanceValue = 5;

        public const string NaturalResistanceRequiredSkill = "Iron Skin";
        public const string NaturalResistanceRequiredSkillDesc = "Required Skill: ";

        public static List<string> naturalResistanceDesc = new List<string>
        {
            NaturalResistanceName,
            NaturalResistanceDescription,
            NaturalResistanceValueDesc,
            String.Concat(NaturalResistanceRequiredSkillDesc, NaturalResistanceRequiredSkill),
            String.Concat(NaturalResistanceRequiredLevelDesc, NaturalResistanceRequiredLevel.ToString()),
        };

        //Shout
        public const string ShoutName = "Shout";
        public const string ShoutDescription = "A loud shout that increases your defense by improving your awareness and morale in battle.";

        public const string ShoutFirstLevelValueDesc = "First level: Defense +1600";
        public const int ShoutFirstLevelValue = 1600;

        public const string ShoutDefenseValueDesc = "Defense per each skill level when active: +25%";
        public const double ShoutDefenseValue = 1.25;

        public const string ShoutRoundDurationDesc = "Round duration per each skill level: + ";
        public const int ShoutRoundDuration = 1;

        public const string ShoutRequiredSkill = "None";
        public const string ShoutRequiredSkillDesc = "Required Skill: ";

        public const string ShoutRequiredLevelDesc = "Required Level: ";
        public const int ShoutRequiredLevel = 1;

        public const string ShoutManaCostDesc = "Mana Cost: ";
        public const int ShoutManaCost = 8;

        public const string ShoutGetsBonusFrom = "Shout gets bonus from the following skills:";
        public const string ShoutBonusFromBattleOrders = "Battle Orders: +10% defense per each skill level when Shout is active";
        public const double ShoutBattleOrdersBonusValue = 1.1;

        public const string ShoutBonusFromWarCry = "WarCry: +10% defense per each skill level when Shout is active";
        public const double ShoutWarCryBonusValue = 1.1;

        public static List<string> shoutDesc = new List<string>
        {
            ShoutName,
            ShoutDescription,
            ShoutFirstLevelValueDesc,
            ShoutDefenseValueDesc,
            String.Concat(ShoutRequiredSkillDesc, ShoutRequiredSkill),
            String.Concat(ShoutRequiredLevelDesc, ShoutRequiredLevel.ToString()),
            String.Concat(ShoutRoundDurationDesc, ShoutRoundDuration.ToString()),
            String.Concat(ShoutManaCostDesc, ShoutManaCost.ToString()),
            ShoutGetsBonusFrom,
            ShoutBonusFromBattleOrders,
            ShoutBonusFromWarCry
        };

        //Battle Orders
        public const string BattleOrdersName = "Battle Orders";
        public const string BattleOrdersDescription = "Increases your base life and mana when active.";

        public const string BattleOrdersRequiredLevelDesc = "Required Level: ";
        public const int BattleOrdersRequiredLevel = 8;

        public const string BattleOrdersRequiredSkill = "Shout";
        public const string BattleOrdersRequiredSkillDesc = "Required Skill: ";

        public const string BattleOrdersLifeValueDesc = "Base life per each skill level when active: +20%";
        public const double BattleOrdersLifeValue = 1.2;

        public const string BattleOrdersManaValueDesc = "Base mana per each skill level when active: +20%";
        public const double BattleOrdersManaValue = 1.2;

        public const string BattleOrdersRoundDurationDesc = "Round duration per each skill level: + ";
        public const int BattleOrdersRoundDuration = 1;

        public const string BattleOrdersManaCostDesc = "Mana Cost: ";
        public const int BattleOrdersManaCost = 25;

        public const string BattleOrdersGetsBonusFrom = "Battle Orders gets bonus from the following skills:";
        public const string BattleOrdersBonusFromShout = "Shout: +5% base life and mana per each skill level when Battle Orders is active";
        public const double BattleOrdersShoutBonusValue = 1.05;

        public const string BattleOrdersBonusFromWarCry = "WarCry: +10% base life and mana per each skill level when Battle Orders is active";
        public const double BattleOrdersWarCryBonusValue = 1.1;

        public static List<string> battleOrdersDesc = new List<string>
        {
            BattleOrdersName,
            String.Concat(BattleOrdersRequiredLevelDesc, BattleOrdersRequiredLevel.ToString()),
            String.Concat(BattleOrdersRequiredSkillDesc, BattleOrdersRequiredSkill),
            BattleOrdersDescription,
            BattleOrdersLifeValueDesc,
            BattleOrdersManaValueDesc,
            String.Concat(BattleOrdersRoundDurationDesc, BattleOrdersRoundDuration.ToString()),
            String.Concat(BattleOrdersManaCostDesc, BattleOrdersManaCost.ToString()),
            BattleOrdersGetsBonusFrom,
            BattleOrdersBonusFromShout,
            BattleOrdersBonusFromWarCry
        };

        //War Cry
        public const string WarCryName = "War Cry";
        public const string WarCryDescription = "Increases all your developed skills' levels when active.";

        public const string WarCryRequiredLevelDesc = "Required Level: ";
        public const int WarCryRequiredLevel = 18;

        public const string WarCryRequiredSkill = "Battle Orders";
        public const string WarCryRequiredSkillDesc = "Required Skill: ";

        public const string WarCrySkillLevelValueDesc = "All other developed skills' levels per each War Cry skill level: + ";
        public const byte WarCrySkillLevelValue = 1;

        public const string WarCryRoundDurationDesc = "Round duration per each skill level: + ";
        public const int WarCryRoundDuration = 1;

        public const string WarCryManaCostDesc = "Mana Cost: ";
        public const int WarCryManaCost = 100;

        public static List<string> warCryDesc = new List<string>
        {
            WarCryName,
            String.Concat(WarCryRequiredLevelDesc, WarCryRequiredLevel.ToString()),
            String.Concat(WarCryRequiredSkillDesc, WarCryRequiredSkill),
            WarCryDescription,
            String.Concat(WarCrySkillLevelValueDesc, WarCrySkillLevelValue.ToString()),
            String.Concat(WarCryRoundDurationDesc, WarCryRoundDuration.ToString()),
            String.Concat(WarCryManaCostDesc, WarCryManaCost.ToString())
        };

        //Stun
        public const string StunName = "Stun";
        public const string StunDescription = "Stuns the enemy and decreases his accuracy with a powerful hit.";

        public const string StunFirstLevelValueDesc = "First level: Damage +75";
        public const int StunFirstLevelValue = 75;

        public const string StunRequiredSkill = "None";
        public const string StunRequiredSkillDesc = "Required Skill: ";

        public const string StunRequiredLevelDesc = "Required Level: ";
        public const int StunRequiredLevel = 6;

        public const string StunDamageValueDesc = "Physical damage per each skill level: +10%";
        public const double StunDamageValue = 1.10;

        public const string StunDefenseValueDesc = "Decreases enemy's damage with 5% for each skill level.";
        public const int StunEnemyDamageDecreaser = 5;

        public const string StunManaCostDesc = "Mana Cost: ";
        public const int StunManaCost = 10;

        public const string StunGetsBonusFrom = "Stun gets bonus from the following skills:";
        public const string StunBonusFromFerocity = "Ferocity: +7% damage per each skill level";
        public const double StunFerocityBonusValue = 1.07;

        public const string StunBonusFromBerzerk = "Berzerk: +7% damage per each skill level";
        public const double StunBerzerkBonusValue = 1.07;

        public const string StunBonusFromWhirlwind = "Whirlwind: +7% damage per each skill level";
        public const double StunWhirlwindBonusValue = 1.07;

        public static List<string> stunDesc = new List<string>
        {
            StunName,
            String.Concat(StunRequiredSkillDesc, StunRequiredSkill),
            String.Concat(StunRequiredLevelDesc, StunRequiredLevel.ToString()),
            StunDescription,
            StunFirstLevelValueDesc,
            StunDamageValueDesc,
            StunDefenseValueDesc,
            String.Concat(StunManaCostDesc, StunManaCost.ToString()),
            StunGetsBonusFrom,
            StunBonusFromFerocity,
            StunBonusFromBerzerk,
            StunBonusFromWhirlwind
        };

        //Ferocity
        public const string FerocityName = "Ferocity";
        public const string FerocityDescription = "You cause trample damage.";

        public const string FerocityRequiredLevelDesc = "Required Level: ";
        public const int FerocityRequiredLevel = 12;

        public const string FerocityRequiredSkill = "Stun";
        public const string FerocityRequiredSkillDesc = "Required Skill: ";

        public const string FerocityFirstLevelValueDesc = "First level: Damage +250";
        public const int FerocityFirstLevelValue = 250;

        public const string FerocityDamageIncreaserDesc = "Physical damage per each skill level: +15%";
        public const double FerocityDamageIncreaser = 1.15;

        public const string FerocityManaCostDesc = "Mana Cost: ";
        public const int FerocityManaCost = 40;

        public const string FerocityGetsBonusFrom = "Ferocity gets bonus from the following skills:";
        public const string FerocityBonusFromStun = "Stun: +7% damage per each skill level";
        public const double FerocityStunBonusValue = 1.07;

        public const string FerocityBonusFromBerzerk = "Berzerk: +7% damage per each skill level";
        public const double FerocityBerzerkBonusValue = 1.07;

        public const string FerocityBonusFromWhirlwind = "Whirlwind: +7% damage per each skill level";
        public const double FerocityWhirlwindBonusValue = 1.07;

        public static List<string> ferocityDesc = new List<string>
        {
            FerocityName,
            String.Concat(FerocityRequiredLevelDesc, FerocityRequiredLevel.ToString()),
            String.Concat(FerocityRequiredSkillDesc, FerocityRequiredSkill),
            FerocityDescription,
            FerocityFirstLevelValueDesc,
            FerocityDamageIncreaserDesc,
            String.Concat(FerocityManaCostDesc, FerocityManaCost.ToString()),
            FerocityGetsBonusFrom,
            FerocityBonusFromStun,
            FerocityBonusFromBerzerk,
            FerocityBonusFromWhirlwind
        };

        //Berzerk
        public const string BerzerkName = "Berzerk";
        public const string BerzerkDescription = "A reckless but powerful attack that increases the damage significantly but abolishes your defense.";

        public const string BerzerkRequiredLevelDesc = "Required Level: ";
        public const int BerzerkRequiredLevel = 18;

        public const string BerzerkRequiredSkill = "Ferocity";
        public const string BerzerkRequiredSkillDesc = "Required Skill: ";

        public const string BerzerkFirstLevelValueDesc = "First level: Damage +500";
        public const int BerzerkFirstLevelValue = 500;

        public const string BerzerkDamageIncreaserDesc = "Physical damage per each skill level: +30%";
        public const double BerzerkDamageIncreaser = 1.3;

        public const string BerzerkDefenseValueDesc = "For skill level 1: divides your defense by 20. For each skill level developed the divider is reduced by 1.";
        public const int BerzerkDefenseDivider = 20;

        public const string BerzerkManaCostDesc = "Mana Cost: ";
        public const int BerzerkManaCost = 100;

        public const string BerzerkGetsBonusFrom = "Berzerk gets bonus from the following skills:";
        public const string BerzerkBonusFromStun = "Stun: +5% damage per each skill level";
        public const double BerzerkStunBonusValue = 1.05;
                            
        public const string BerzerkBonusFromFerocity = "Ferocity: +10% damage per each skill level";
        public const double BerzerkFerocityBonusValue = 1.1;

        public static List<string> berzerkDesc = new List<string>
        {
            BerzerkName,
            String.Concat(BerzerkRequiredLevelDesc, BerzerkRequiredLevel.ToString()),
            String.Concat(BerzerkRequiredSkillDesc, BerzerkRequiredSkill),
            BerzerkFirstLevelValueDesc,
            BerzerkDescription,
            BerzerkDamageIncreaserDesc,
            BerzerkDefenseValueDesc,
            String.Concat(BerzerkManaCostDesc, BerzerkManaCost.ToString()),
            BerzerkGetsBonusFrom,
            BerzerkBonusFromStun,
            BerzerkBonusFromFerocity
        };

        //Whirlwind
        public const string WhirlwindName = "Whirlwind";
        public const string WhirlwindDescription = "A deadly spinning dance that allows you multiple hits on your target.";

        public const string WhirlwindRequiredLevelDesc = "Required Level: ";
        public const int WhirlwindRequiredLevel = 18;

        public const string WhirlwindRequiredSkill = "Ferocity";
        public const string WhirlwindRequiredSkillDesc = "Required Skill: ";

        public const string WhirlwindHitsValueDesc = "Bonus hits per each skill level: + ";
        public const int WhirlwindHitsValue = 1;

        public const string WhirlwindManaCostDesc = "Mana Cost: ";
        public const int WhirlwindManaCost = 100;

        public const string WhirlwindGetsBonusFrom = "Whirlwind gets bonus from the following skills:";
        public const string WhirlwindBonusFromStun = "Stun: +5% damage per each skill level";
        public const double WhirlwindStunBonusValue = 1.05;

        public const string WhirlwindBonusFromFerocity = "Ferocity: +10% damage per each skill level";
        public const double WhirlwindFerocityBonusValue = 1.1;

        public static List<string> whirlwindDesc = new List<string>
        {
            WhirlwindName,
            String.Concat(WhirlwindRequiredLevelDesc, WhirlwindRequiredLevel.ToString()),
            String.Concat(WhirlwindRequiredSkillDesc, WhirlwindRequiredSkill),
            WhirlwindDescription,
            String.Concat(WhirlwindHitsValueDesc, WhirlwindHitsValue.ToString()),
            String.Concat(WhirlwindManaCostDesc, WhirlwindManaCost.ToString()),
            WhirlwindGetsBonusFrom,
            WhirlwindBonusFromStun,
            WhirlwindBonusFromFerocity
        };
    }
}
